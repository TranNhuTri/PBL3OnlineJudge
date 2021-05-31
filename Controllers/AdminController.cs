using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PBL3.Models;
using PBL3.DTO;
using PBL3.Data;
using Microsoft.EntityFrameworkCore;
using PBL3.General;

namespace PBL3.Controllers
{
    public class AdminController : Controller
    {
        private readonly PBL3Context _context;
        public AdminController(PBL3Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListProblems(int? page, int authorId, int? isPublic, string searchText)
        {
            ViewData["ListAuthors"] = _context.Accounts.Where(p => p.typeAccount == 2 || p.typeAccount == 1).OrderBy(p => p.accountName).ToList();
            
            var listProblems = _context.Problems.Include(p => p.problemAuthors)
                                                .ThenInclude(p => p.author)
                                                .ToList();

            if(authorId != 0)
            {
                listProblems =  listProblems.Where(p => p.problemAuthors.Select(p => p.authorID).ToList().Contains(authorId))
                                            .ToList();
            }

            if(isPublic == 1)
            {
                listProblems =  listProblems.Where(p => p.isPublic == true)
                                            .ToList();
            }
            else
                if(isPublic == 0)
                {
                    listProblems =  listProblems.Where(problem => problem.isPublic == false)
                                                .ToList();
                }

            if(!String.IsNullOrEmpty(searchText))
            {
                listProblems =  listProblems.Where(problem => problem.title.ToLower().Contains(searchText.ToLower()) || problem.code.ToLower().Contains(searchText.ToLower()))
                                            .ToList();
            }
            if(page == null)
            {
                page = 1;
            }
            
            int limit = Utility.limitData;

            int start = (int)(page - 1)*limit;

            ViewBag.currentPage = page;

            ViewBag.totalPage = (int)Math.Ceiling((float)listProblems.Count/limit);

            listProblems = listProblems.Skip(start).Take(limit).ToList();

            return View(listProblems.OrderByDescending(p => p.timeCreate).ToList());
        }
        public IActionResult ListProblemCategories(int? page, string categoryName)
        {
            var listProblemCategories = _context.Categories.ToList();

            if(!string.IsNullOrEmpty(categoryName))
            {
                listProblemCategories = listProblemCategories.Where(p => p.name.ToLower().Contains(categoryName.ToLower())).ToList();
            }

            if(page == null)
            {
                page = 1;
            }
            
            int limit = Utility.limitData;

            int start = (int)(page - 1)*limit;

            ViewBag.currentPage = page;

            ViewBag.totalPage = (int)Math.Ceiling((float)listProblemCategories.Count/limit);

            listProblemCategories = listProblemCategories.Skip(start).Take(limit).ToList();

            return View(listProblemCategories);
        }
        public IActionResult AddProblemCategory()
        {
            ViewData["listProblems"] = _context.Problems.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProblemCategory([Bind("name")] Category reqCategory, List<int> reqListProblemIds)
        {
            ViewData["listProblems"] = _context.Problems.ToList();
            ViewData["listChosenProblemIDs"] = reqListProblemIds;

            if(ModelState.IsValid)
            {
                var category = _context.Categories.FirstOrDefault(p => p.name.ToLower().Contains(reqCategory.name.ToLower()));

                if(category != null)
                {
                    ModelState.AddModelError("", "Dạng bài đã tồn tại !");
                    return View();
                }

                _context.Add(reqCategory);

                foreach(int id in reqListProblemIds)
                {
                    var problemClassification = new ProblemClassification()
                    {
                        problemID = id,
                        category = reqCategory
                    };
                    _context.Add(problemClassification);
                }
                await _context.SaveChangesAsync();

                return RedirectToAction("ListProblemCategories");
            }
            return View();
        }
        public IActionResult EditProblemCategory(int id)
        {
            ViewData["ListProblems"] = _context.Problems.ToList();

            ViewData["ListChosenProblemIds"] = _context.ProblemClassifications.Where(p => p.categoryID == id).Select(p => p.problemID).ToList();

            var problemCategory = _context.Categories.FirstOrDefault(p =>p .ID == id);

            return View(problemCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProblemCategory(int id, [Bind("name")] Category reqCategory, List<int> reqListProblemIds)
        {
            ViewData["ListProblems"] = _context.Problems.ToList();

            ViewData["ListChosenProblemIds"] = reqListProblemIds.ToList();

            if(ModelState.IsValid)
            {
                var problemCategory = _context.Categories.FirstOrDefault(cate => cate.ID == id);
                if(problemCategory == null)
                {
                    return NotFound();
                }

                if(problemCategory.name != reqCategory.name && _context.Categories.FirstOrDefault(p => p.name == reqCategory.name) != null)
                {
                    ModelState.AddModelError("", "Dạng bài đã tồn tại");
                    return View(reqCategory);
                }
                var listProblemClassifications = _context.ProblemClassifications.Where(pc => pc.categoryID == id).ToList();

                // var lstTmpt = new List<ProblemClassification>();

                // lstTmpt.AddRange(listProblemClassifications.Select(pc => pc));

                foreach(var item in listProblemClassifications)
                {
                    //xoa
                    if(reqListProblemIds.Any(p => p == item.problemID) == false)
                    {
                        _context.Remove(item);
                    }
                }
                foreach(var item in reqListProblemIds)
                {
                    //them
                    if(listProblemClassifications.Any(p => p.problemID == item) == false)
                    {
                        _context.Add(new ProblemClassification()
                        {
                            problemID = item,
                            categoryID = id
                        });
                    }
                }

                problemCategory.name = reqCategory.name;

                // _context.ProblemClassifications.RemoveRange(listProblemClassifications);

                // _context.AddRange(lstTmpt);

                await _context.SaveChangesAsync();

                return RedirectToAction("ListProblemCategories");
            }

            return View(reqCategory);
        }
        public IActionResult ListAccounts(int? page, int? isActived, int typeAccount, string searchText)
        {
            var listAccounts = _context.Accounts.OrderBy(p => p.accountName).ToList();

            if(typeAccount != 0)
            {
                listAccounts = listAccounts.Where(p => p.typeAccount == typeAccount).ToList();
            }
            if(isActived == 1)
            {
                listAccounts = listAccounts.Where(p => p.isActived == true).ToList();
            }
            else
                if(isActived == 0)
                {
                    listAccounts = listAccounts.Where(p => p.isActived == false).ToList();
                }
            if(!string.IsNullOrEmpty(searchText))
            {
                listAccounts = listAccounts.Where(p => p.accountName.ToLower().Contains(searchText.ToLower()) || p.email.ToLower().Contains(searchText.ToLower()) || (p.lastName + " " + p.firstName).ToLower().Contains(searchText.ToLower())).ToList();
            }

            if(page == null)
            {
                page = 1;
            }
            
            int limit = Utility.limitData;

            int start = (int)(page - 1)*limit;

            ViewBag.currentPage = page;

            ViewBag.totalPage = (int)Math.Ceiling((float)listAccounts.Count/limit);

            listAccounts = listAccounts.Skip(start).Take(limit).ToList();

            return View(listAccounts);
        }
        public IActionResult EditAccount(int id)
        {
            var account = _context.Accounts.FirstOrDefault(p => p.ID == id);

            if(account == null)
            {
                return NotFound();
            }

            return View(new EditAccount()
            {
                accountName = account.accountName,
                email = account.email,
                typeAccount = account.typeAccount,
                isActived = account.isActived,
                lastName = account.lastName,
                firstName = account.firstName
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAccount(int id, [Bind("accountName", "email", "isActived", "typeAccount", "lastName", "firstName")] EditAccount reqEditAccount)
        {
            if(ModelState.IsValid)
            {
                var account = _context.Accounts.FirstOrDefault(p => p.ID == id);

                if(_context.Accounts.FirstOrDefault(p => p.accountName == reqEditAccount.accountName && p.accountName != account.accountName) != null)
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                    return View();
                }

                account.accountName = reqEditAccount.accountName;
                account.email = reqEditAccount.email;
                account.isActived = reqEditAccount.isActived;
                account.typeAccount = reqEditAccount.typeAccount;
                account.lastName = reqEditAccount.lastName;
                account.firstName = reqEditAccount.firstName;

                _context.Update(account);
                await _context.SaveChangesAsync();

                return RedirectToAction("ListAccounts");
            }
            return View();
        }
        public IActionResult ListSubmissions(int? page, string language, string status, string searchText)
        {
            var listSubmissions = _context.Submissions.Include(p => p.problem).Include(p => p.account).OrderByDescending(p => p.timeCreate).ToList();
            if(language != "all" && !string.IsNullOrEmpty(language))
            {
                listSubmissions = listSubmissions.Where(p => p.language == language).ToList();
            }
            if(status != "all" && !string.IsNullOrEmpty(language))
            {
                listSubmissions = listSubmissions.Where(p => p.status == status).ToList();
            }
            if(!string.IsNullOrEmpty(searchText))
            {
                listSubmissions = listSubmissions.Where(p => p.problem.title.ToLower().Contains(searchText.ToLower()) || p.problem.code.ToLower().Contains(searchText.ToLower()) || p.account.accountName.ToLower().Contains(searchText.ToLower())).ToList();
            }
            
            if(page == null)
            {
                page = 1;
            }
            
            int limit = Utility.limitData;

            int start = (int)(page - 1)*limit;

            ViewBag.currentPage = page;

            ViewBag.totalPage = (int)Math.Ceiling((float)listSubmissions.Count/limit);

            listSubmissions = listSubmissions.Skip(start).Take(limit).ToList();

            return View(listSubmissions);
        }
        public IActionResult Submission(int id)
        {
            var submission = _context.Submissions.Include(p => p.problem).Include(p => p.account).Include(p => p.submissionResults).FirstOrDefault(p => p.ID == id);

            if(submission == null)
            {
                return NotFound();
            }

            return View(submission);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSubmission(int id)
        {
            var submission = _context.Submissions.Include(p => p.problem).Include(p => p.account).FirstOrDefault(p => p.ID == id);

            if(submission == null)
            {
                return NotFound();
            }

            _context.Remove(submission);

            _context.SaveChanges();

            return RedirectToAction("ListSubmissions");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
