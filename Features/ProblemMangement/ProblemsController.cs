using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PBL3.Models;
using PBL3.DTO;
using PBL3.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PBL3.General;
using Microsoft.AspNetCore.Authorization;
using PBL3.Features.CategoryManagement;
using PBL3.Features.SubmissionManagement;
using PBL3.Features.AccountManagement;
using PBL3.Repositories;
using PBL3.Features.CommentManagement;
using PBL3.Features.LikeManagement;

namespace PBL3.Features.ProblemManagement
{
    public class ProblemsController : Controller
    {
        private readonly IRepository<PBL3.Models.Action> _actionRepo;
        private readonly IRepository<ProblemAuthor> _problemAuthorRepo;
        private readonly IRepository<ProblemClassification> _problemClassificationRepo;
        private readonly IRepository<TestCase> _testCaseRepo;
        private readonly IProblemService _problemService;
        private readonly ICategoryService _categoryService;
        private readonly ISubmissionService _submissionService;
        private readonly IAccountService _accountService;
        private readonly ICommentService _commentService;
        private readonly ILikeService _likeService;
        public ProblemsController(IRepository<PBL3.Models.Action> actionRepo, IRepository<ProblemAuthor> problemAuthorRepo,IRepository<ProblemClassification> problemClassificationRepo, IRepository<TestCase> testCaseRepo, IProblemService problemService, ICategoryService categoryService, ISubmissionService submissionService, IAccountService accountService, ICommentService commentService, ILikeService likeService)
        {
            _actionRepo = actionRepo;
            _problemAuthorRepo = problemAuthorRepo;
            _problemClassificationRepo = problemClassificationRepo;
            _testCaseRepo = testCaseRepo;
            _problemService = problemService;
            _categoryService = categoryService;
            _submissionService = submissionService;
            _accountService = accountService;
            _commentService = commentService;
            _likeService = likeService;
        }
        public IActionResult Index(int? page, string problemName, bool hideSolvedProblem, List<int> categoryIds, int? minDifficult, int? maxDifficult)
        {
            // set paramater page
            var paramater = new Dictionary<string, string>();  
            if (!string.IsNullOrEmpty(problemName))
                paramater.Add("problemName", problemName);
            if (minDifficult != null)
                paramater.Add("minDifficult", minDifficult.ToString());
            if (maxDifficult != null)
                paramater.Add("maxDifficult", maxDifficult.ToString());
            var accountID = 0;
            if (HttpContext.User.Identity.IsAuthenticated)
                accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);
            if (hideSolvedProblem) 
                paramater.Add("hideSolvedProblem", hideSolvedProblem.ToString()); 
            ViewBag.paginationParams = paramater;

            
            var listProblems = _problemService.GetListSearchProblem(problemName, categoryIds, minDifficult, maxDifficult);
            if(!HttpContext.User.Identity.IsAuthenticated || HttpContext.User.Claims.FirstOrDefault(p => p.Type == "Role").Value == "User")
                listProblems = listProblems.Where(p => p.isPublic == true).Select(p => p).ToList();
            if (hideSolvedProblem) {
                listProblems = listProblems
                .Where(p => _submissionService.GetSubmissionsByAccountProblemID(accountID, p.ID, true).Count == 0).ToList();
            }

            //pagination
            if(page == null) page = 1;
            int limit = Utility.limitData;
            int start = (int)(page - 1)*limit;
            ViewBag.currentPage = page;
            ViewBag.totalPage = (int)Math.Ceiling((float)listProblems.Count/limit);
            listProblems = listProblems.Skip(start).Take(limit).OrderByDescending(p => p.timeCreate).ToList();


            var problemSubmssions = new List<int>();
            var problemACSubmissions = new List<int>();
            var problemSubmissionsByAccount = new List<int>();
            var problemSubmissionsACByAccount = new List<int>();

            foreach(var item in listProblems)
            {
                item.submissions = _submissionService.GetAllSubmissionsByProblemID(item.ID);
                problemSubmssions.Add(item.submissions.Count);
                problemACSubmissions.Add(item.submissions.Where(p => p.status == "Accepted").Count());
                if (accountID > 0) 
                {
                    problemSubmissionsByAccount.Add(item.submissions.Where(p => p.accountID == accountID).Count());
                    problemSubmissionsACByAccount.Add(item.submissions.Where(p => p.accountID == accountID && p.status == "Accepted").Count());
                }
            }


            ViewData["SearchProblemInfor"] = new SearchProblemInfor
            {
                problemName = problemName,
                minDifficult = minDifficult,
                maxDifficult = maxDifficult,
                hideSolvedProblem = hideSolvedProblem
            };

            ViewData["ListCategories"] = _categoryService.GetAllCategories();
            ViewData["ListChosenCategoryIds"] = categoryIds;
            ViewData["ProblemSubmissions"] = problemSubmssions;
            ViewData["ProblemACSubmissions"] = problemACSubmissions;
            ViewData["ProblemSubmissionsByAccount"] = problemSubmissionsByAccount;
            ViewData["ProblemSubmissionsACByAccount"] = problemSubmissionsACByAccount;

            return View(listProblems);
        }
        [Authorize(Roles ="Admin, Author")]
        public IActionResult AddProblem()
        {
            ViewData["listAuthors"] = _accountService.GetAllAuthor().OrderBy(p => p.accountName).ToList();

            ViewData["listCategories"] = _categoryService.GetAllCategories();

            return View();
        }
        [Authorize(Roles ="Admin, Author")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProblem([Bind("code, title, content, difficulty, timeLimit, memoryLimit, isPublic")] Problem reqProblem, List<int> reqListAuthorIds, List<int> reqListCategoryIds, string next)
        {
            ViewData["ListAuthors"] = _accountService.GetAllAuthor().OrderBy(p => p.accountName).ToList();

            ViewData["ListCategories"] = _categoryService.GetAllCategories();

            ViewData["ListChosenAuthorIds"] = reqListAuthorIds;

            ViewData["ListChosenCategoryIds"] = reqListCategoryIds;

            if (ModelState.IsValid)
            {
                if(_problemService.GetNonDeletedProblemByCode(reqProblem.code) != null)
                {
                    ModelState.AddModelError("", "Mã bài đã tồn tại");
                    return View();
                }
                if(_problemService.GetNonDeletedProblemByTitle(reqProblem.title) != null)
                {
                    ModelState.AddModelError("", "Tên bài đã tồn tại");
                    return View();
                }

                _problemService.AddProblem(reqProblem, reqListAuthorIds, reqListCategoryIds, Convert.ToInt32(HttpContext.User.Claims.Where(p => p.Type == "UserID").FirstOrDefault().Value));

                if(next == "edit")
                {
                    return RedirectToAction("Edit", "Problem", new {id = reqProblem.ID});
                }
                return RedirectToAction("Problems", "Admin");
            }
            ModelState.AddModelError("", "Hãy sửa các thông tin không đúng yêu cầu");
            return View();
        }
        public IActionResult Problem(int id)
        {
            var problem = _problemService.GetProblemByID(id);
            if(problem == null || problem.isDeleted == true)
            {
                return NotFound();
            }

            problem.problemAuthors = _problemAuthorRepo.GetAll().Where(p => p.problemID == id).ToList();
            problem.problemClassifications = _problemClassificationRepo.GetAll().Where(p => p.problemID == id).ToList();
            foreach(var item in problem.problemAuthors)
                item.author = _accountService.GetAccountByID(item.authorID);
            foreach(var item in problem.problemClassifications)
                item.category = _categoryService.GetCategoryByID(item.categoryID);
            
            var comments = _commentService.GetCommentsByProblemID(id).Where(p => p.level == 1).ToList();
            foreach(var item in comments)
                item.account = _accountService.GetAccountByID(item.accountID);
            foreach(var item in comments)
                item.likes = _likeService.GetLikesByCommentID(item.ID);
            foreach(var item in comments)
                item.child = _commentService.GetListCommentsByRootCommentID(item.ID);

            ViewData["ListComments"] = comments;

            return View(problem);
        }
        [Authorize(Roles ="Admin, Author")]
        public IActionResult DeleteProblem(int? id)
        {
            var problem = _problemService.GetProblemByID((int)id);
            problem.submissions = _submissionService.GetAllSubmissionsByProblemID((int)id);
            foreach(var item in problem.submissions)
                item.account = _accountService.GetAccountByID(item.accountID);

            return View(problem);
        }
        [Authorize(Roles ="Admin, Author")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProblem(int id)
        {
            var problem = _problemService.GetProblemByID(id);

            if(problem == null)
                return NotFound();
            
            _problemService.ChangeIsDeleted(id, Convert.ToInt32(HttpContext.User.Claims.Where(p => p.Type == "UserID")));

            return RedirectToAction("Problems", "Admin");
        }
        [Authorize(Roles ="Admin, Author")]
        public IActionResult EditProblem(int id)
        {
            var problem = _problemService.GetProblemByID(id);
            
            ViewData["ListAuthors"] = _accountService.GetAllAuthor().OrderBy(p => p.accountName).ToList();

            ViewData["ListCategories"] = _categoryService.GetAllCategories();

            ViewData["ListChosenAuthorIds"] = _problemAuthorRepo.GetAll().Where(p => p.problemID == id && p.isDeleted == false).Select(p => p.authorID).ToList();

            ViewData["ListChosenCategoryIds"] = _problemClassificationRepo.GetAll().Where(p => p.problemID == id && p.isDeleted == false).Select(p => p.categoryID).ToList();

            ViewBag.problemTestCases = _testCaseRepo.GetAll().Where(p => p.problemID == id && p.isDeleted == false).ToList();

            return View(problem);
        }
        [Authorize(Roles ="Admin, Author")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProblem(int id, [Bind("code, title, content, difficulty, isPublic, timeLimit, memoryLimit")] Problem reqProblem, List<int> reqListAuthorIds, List<int> reqListCategoryIds, string next)
        {
            if(_problemService.GetProblemByID(id) == null)
            {
                return NotFound();
            }
            ViewData["ListAuthors"] = _accountService.GetAllAuthor().OrderBy(p => p.accountName).ToList();

            ViewData["ListCategories"] = _categoryService.GetAllCategories();

            ViewData["ListChosenAuthorIds"] = reqListAuthorIds;

            ViewData["ListChosenCategoryIds"] = reqListCategoryIds;

            ViewBag.problemTestCases = _testCaseRepo.GetAll().Where(p => p.problemID == id && p.isDeleted == false).ToList();

            if(ModelState.IsValid)
            {
                int accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);
                _problemService.UpdateProblem(id ,reqProblem, reqListAuthorIds, reqListCategoryIds, accountID);
                if(next == "edit")
                {
                    return RedirectToAction("EditProblem", id);
                }
                return RedirectToAction("Problems", "Admin");
            }
            ModelState.AddModelError("", "Hãy sửa các thông tin không đúng yêu cầu");
            return View(reqProblem);
        }
        [Authorize(Roles ="Admin, Author")]
        public IActionResult ProblemHistory(int id)
        {
            var problem = _problemService.GetProblemByID(id);
            if(problem == null)
            {
                return NotFound();
            }
            var listActions = _actionRepo.GetAll().Where(p => p.objectID == id && p.typeObject == Convert.ToInt32(TypeObject.Problem)).OrderByDescending(p => p.dateTime).ToList();
            foreach(var item in listActions)
            {
                item.account = _accountService.GetAccountByID(item.accountID);
            }
            return View(listActions);
        }
        [Authorize(Roles ="Admin, Author")]
        public IActionResult DeletedProblems(int? page)
        {
            var problems = _problemService.GetAllDeletedProblems();

            var listDates = new List<DateTime>();

            foreach(var item in problems)
            {
                var action = _actionRepo.GetAll().Where(p => p.objectID == item.ID && p.typeObject == (int)TypeObject.Problem).OrderByDescending(p => p.dateTime).First();
                listDates.Add(action.dateTime);
            }
            
            ViewBag.deleteDates = listDates;

            if(page == null) page = 1;

            int limit = Utility.limitData;
            int start = (int)(page - 1)*limit;

            ViewBag.currentPage = page;

            ViewBag.totalPage = (int)Math.Ceiling((float)problems.Count/limit);

            problems = problems.Skip(start).Take(limit).ToList();

            return View(problems);
        }
        [Authorize(Roles ="Admin, Author")]
        public IActionResult RestoreProblem(int id)
        {
            var problem = _problemService.GetProblemByID(id);
            
            ViewData["ListAuthors"] = _accountService.GetAllAuthor();

            ViewData["ListCategories"] = _categoryService.GetAllCategories();

            ViewData["ListChosenAuthorIds"] = _problemAuthorRepo.GetAll().Where(p => p.problemID == id && p.isDeleted == false).Select(p => p.authorID).ToList();

            ViewData["ListChosenCategoryIds"] = _problemClassificationRepo.GetAll().Where(p =>p.problemID == id &&  p.isDeleted == false).Select(p => p.categoryID).ToList();

            if(problem == null)
            {
                return NotFound();
            }
            return View(problem);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin, Author")]
        public IActionResult RestoreProblem(int? id)
        {
            var problem = _problemService.GetProblemByID((int)id);
            
            ViewData["ListAuthors"] = _accountService.GetAllAuthor();

            ViewData["ListCategories"] = _categoryService.GetAllCategories().OrderBy(p => p.name).ToList();

            ViewData["ListChosenAuthorIds"] = _problemAuthorRepo.GetAll().Where(p => p.problemID == id && p.isDeleted == false).Select(p => p.authorID).ToList();

            ViewData["ListChosenCategoryIds"] = _problemClassificationRepo.GetAll().Where(p =>p.problemID == id &&  p.isDeleted == false).Select(p => p.categoryID).ToList();

            if(problem == null)
            {
                return NotFound();
            }

            if(_problemService.GetNonDeletedProblemByTitle(problem.title) != null || _problemService.GetNonDeletedProblemByCode(problem.code) != null)
            {
                ModelState.AddModelError("", "Không thể khôi phục bài vì đã có bài trùng tên hoặc mã bài");
                return View(problem);
            }

            _problemService.ChangeIsDeleted((int)id, Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value));

            return RedirectToAction("Problems", "Admin");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
