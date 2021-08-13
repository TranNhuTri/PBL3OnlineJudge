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

namespace PBL3.Features.ProblemManagement
{
    public class ProblemsController : Controller
    {
        private readonly PBL3Context _context; // nho bo di
        private readonly IRepository<PBL3.Models.Action> _actionRepo;
        private readonly IProblemService _problemService;
        private readonly ICategoryService _categoryService;
        private readonly ISubmissionService _submissionService;
        private readonly IAccountService _accountService;
        public ProblemsController(IRepository<PBL3.Models.Action> actionRepo, IProblemService problemService, ICategoryService categoryService, ISubmissionService submissionService, IAccountService accountService, PBL3Context context)
        {
            _context = context;
            _actionRepo = actionRepo;
            _problemService = problemService;
            _categoryService = categoryService;
            _submissionService = submissionService;
            _accountService = accountService;
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
            ViewData["listAuthors"] = _context.Accounts.Where(p => (p.roleID == 2 || p.roleID == 1) && p.isActived == true && p.isDeleted == false).OrderBy(p => p.accountName).ToList();

            ViewData["listCategories"] = _categoryService.GetAllCategories();

            return View();
        }
        [Authorize(Roles ="Admin, Author")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProblem([Bind("code, title, content, difficulty, timeLimit, memoryLimit, isPublic")] Problem reqProblem, List<int> reqListAuthorIds, List<int> reqListCategoryIds, string next)
        {
            ViewData["ListAuthors"] = _context.Accounts.Where(p => (p.roleID == 2 || p.roleID == 1) && p.isActived == true && p.isDeleted == false).OrderBy(p => p.accountName).ToList();

            ViewData["ListCategories"] = _categoryService.GetAllCategories();

            ViewData["ListChosenAuthorIds"] = reqListAuthorIds;

            ViewData["ListChosenCategoryIds"] = reqListCategoryIds;

            if (ModelState.IsValid)
            {
                if(_context.Problems.Where(p => p.isDeleted == false).FirstOrDefault(p => p.code == reqProblem.code) != null)
                {
                    ModelState.AddModelError("", "Mã bài đã tồn tại");
                    return View();
                }
                if(_context.Problems.Where(p => p.isDeleted == false).FirstOrDefault(p => p.title == reqProblem.title) != null)
                {
                    ModelState.AddModelError("", "Tên bài đã tồn tại");
                    return View();
                }
                reqProblem.timeCreate = DateTime.Now;

                foreach(var item in reqListAuthorIds)
                {
                    _context.Add(new ProblemAuthor()
                    {
                        problem = reqProblem,
                        authorID = item
                    });
                }
                foreach(int id in reqListCategoryIds)
                { 
                    _context.Add(new ProblemClassification()
                    {
                        problem = reqProblem,
                        categoryID = id
                    });
                }

                _problemService.AddProblem(reqProblem);

                _actionRepo.Insert(new PBL3.Models.Action()
                {
                    accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value),
                    objectID = reqProblem.ID,
                    dateTime = DateTime.Now,
                    action = "Tạo mới",
                    typeObject = Convert.ToInt32(TypeObject.Problem)
                });

                _actionRepo.Save();

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
            var problem = _context.Problems.Where(p => p.ID == id)
                                            .Include(p => p.problemAuthors)
                                            .ThenInclude(p => p.author)
                                            .Include(p => p.problemClassifications)
                                            .ThenInclude(p => p.category)
                                            .Include(p => p.submissions)
                                            .ThenInclude(s => s.account).AsSplitQuery().OrderByDescending(p => p.timeCreate)
                                            .FirstOrDefault();
            if(problem == null || problem.isDeleted == true)
            {
                return NotFound();
            }

            ViewData["ListComments"] = _context.Comments.Where(p => p.postID == id && p.level == 1 && p.isHidden == false && p.isDeleted == false)
                                                        .Include(p => p.account)
                                                        .Include(p => p.child)
                                                        .Include(p => p.likes)
                                                        .ThenInclude(p => p.account).AsSplitQuery().OrderByDescending(p => p.timeCreate)
                                                        .ToList();

            return View(problem);
        }
        [Authorize(Roles ="Admin, Author")]
        public IActionResult DeleteProblem(int? id)
        {
            var problem = _context.Problems.Where(p => p.ID == id)
                                            .Include(p => p.submissions)
                                            .ThenInclude(p => p.account)
                                            .Include(p => p.testCases)
                                            .AsSplitQuery().OrderByDescending(p => p.timeCreate)
                                            .FirstOrDefault();
            
            ViewBag.listComments = _context.Comments.Where(p => p.postID == id).Include(p => p.account).ToList();

            return View(problem);
        }
        [Authorize(Roles ="Admin, Author")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProblem(int id)
        {
            var problem = _context.Problems.Where(p => p.ID == id).FirstOrDefault();

            if(problem == null)
                return NotFound();

            _problemService.ChangeIsDeleted(id);

            _submissionService.ChangeIsDeletedSubmissionsByProblemID(id);

            _actionRepo.Insert(new PBL3.Models.Action()
            {
                accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value),
                objectID = problem.ID,
                dateTime = DateTime.Now,
                action = "Xóa bài tập",
                typeObject = Convert.ToInt32(TypeObject.Problem)
            });

            _actionRepo.Save();
            
            return RedirectToAction("Problems", "Admin");
        }
        [Authorize(Roles ="Admin, Author")]
        public IActionResult EditProblem(int id)
        {
            var problem = _context.Problems.Include(p => p.problemAuthors)
                                            .Include(problem => problem.problemClassifications)
                                            .AsSplitQuery().OrderBy(p => p.title)
                                            .FirstOrDefault(p => p.ID == id);
            
            ViewData["ListAuthors"] = _context.Accounts.Where(p => (p.roleID == 2 || p.roleID == 1) && p.isDeleted == false && p.isActived == true).OrderBy(p => p.accountName).ToList();

            ViewData["ListCategories"] = _categoryService.GetAllCategories();

            ViewData["ListChosenAuthorIds"] = problem.problemAuthors.Where(p => p.isDeleted == false).Select(p => p.authorID).ToList();

            ViewData["ListChosenCategoryIds"] = problem.problemClassifications.Where(p => p.isDeleted == false).Select(p => p.categoryID).ToList();

            ViewBag.problemTestCases = _context.TestCases.Where(p => p.problemID == id && p.isDeleted == false).ToList();

            return View(problem);
        }
        [Authorize(Roles ="Admin, Author")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProblem(int id, [Bind("code, title, content, difficulty, isPublic, timeLimit, memoryLimit")] Problem reqProblem, List<int> reqListAuthorIds, List<int> reqListCategoryIds, string next)
        {
            if(_context.Problems.FirstOrDefault(p => p.ID == id) == null)
            {
                return NotFound();
            }
            ViewData["ListAuthors"] = _context.Accounts.Where(p => (p.roleID == 2 || p.roleID == 1) && p.isDeleted == false && p.isActived == true).OrderBy(p => p.accountName).ToList();

            ViewData["ListCategories"] = _categoryService.GetAllCategories();

            ViewData["ListChosenAuthorIds"] = reqListAuthorIds;

            ViewData["ListChosenCategoryIds"] = reqListCategoryIds;

            ViewBag.problemTestCases = _context.TestCases.Where(p => p.problemID == id && p.isDeleted == false).ToList();

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
            var problems = _context.Problems.Where(p => p.isDeleted == true).ToList();

            var listDates = new List<DateTime>();

            foreach(var item in problems)
            {
                var action = _context.Actions.Where(p => p.objectID == item.ID && p.typeObject == (int)TypeObject.Problem).OrderByDescending(p => p.dateTime).First();
                listDates.Add(action.dateTime);
            }
            
            ViewBag.deleteDates = listDates;

            if(page == null)
            {
                page = 1;
            }

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
            var problem = _context.Problems.Include(p => p.problemAuthors)
                                            .Include(problem => problem.problemClassifications)
                                            .AsSplitQuery().OrderBy(p => p.title)
                                            .FirstOrDefault(p => p.ID == id);
            
            ViewData["ListAuthors"] = _context.Accounts.Where(p => p.roleID == 2 || p.roleID == 1).OrderBy(p => p.accountName).ToList();

            ViewData["ListCategories"] = _context.Categories.OrderBy(p => p.name).ToList();

            ViewData["ListChosenAuthorIds"] = problem.problemAuthors.Where(p => p.isDeleted == false).Select(p => p.authorID).ToList();

            ViewData["ListChosenCategoryIds"] = problem.problemClassifications.Where(p => p.isDeleted == false).Select(p => p.categoryID).ToList();

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
            var problem = _context.Problems.Include(p => p.problemAuthors)
                                            .Include(problem => problem.problemClassifications)
                                            .Include(p => p.submissions)
                                            .AsSplitQuery().OrderBy(p => p.title)
                                            .FirstOrDefault(p => p.ID == id);
            
            ViewData["ListAuthors"] = _context.Accounts.Where(p => p.roleID == 2 || p.roleID == 1).OrderBy(p => p.accountName).ToList();

            ViewData["ListCategories"] = _context.Categories.OrderBy(p => p.name).ToList();

            ViewData["ListChosenAuthorIds"] = problem.problemAuthors.Where(p => p.isDeleted == false).Select(p => p.authorID).ToList();

            ViewData["ListChosenCategoryIds"] = problem.problemClassifications.Where(p => p.isDeleted == false).Select(p => p.categoryID).ToList();

            if(problem == null)
            {
                return NotFound();
            }

            if(_context.Problems.FirstOrDefault(p => (p.title == problem.title || p.code == problem.code) && p.isDeleted == false) != null)
            {
                ModelState.AddModelError("", "Không thể khôi phục bài vì đã có bài trùng tên hoặc mã bài");
                return View(problem);
            }

            problem.isDeleted = false;
            _context.Update(problem);

            var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);

            var action = new PBL3.Models.Action()
            {
                account = _context.Accounts.FirstOrDefault(p => p.ID == accountID),
                objectID = problem.ID,
                dateTime = DateTime.Now,
                action = "Khôi phục đề bài",
                typeObject = Convert.ToInt32(TypeObject.Problem)
            };
            _context.Add(action);
            
            _context.SaveChanges();
            return RedirectToAction("Problems", "Admin");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
