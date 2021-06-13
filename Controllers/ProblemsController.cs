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

namespace PBL3.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly PBL3Context _context;
        public ProblemsController(PBL3Context context)
        {
            _context = context;
        }
        public IActionResult Index(int? page, string problemName, bool hideSolvedProblem, List<int> categoryIds, int? minDifficult, int? maxDifficult)
        {
            ViewData["ListCategories"] = _context.Categories.Where(p => p.isDeleted == false).ToList();

            ViewData["ListChosenCategoryIds"] = categoryIds;
            
            var paramater = new Dictionary<string, string>();

            var listProblems = _context.Problems.Include(p => p.submissions)
                                                .Include(p => p.problemClassifications)
                                                .ThenInclude(p => p.category)
                                                .AsSplitQuery()
                                                .OrderByDescending(p => p.timeCreate)
                                                .Where(p => p.isDeleted == false)
                                                .ToList();
            
            if(!String.IsNullOrEmpty(problemName))
            {
                listProblems = listProblems.Where(p => p.title.ToLower().Contains(problemName.ToLower())).ToList();
                paramater.Add("problemName", problemName);
            }
            
            if(categoryIds.Count > 0)
            {
                var lstTmpt = new List<Problem>();
                foreach(var item in listProblems)
                {
                    var tmpt = item.problemClassifications.Where(p => p.category.isDeleted == false && p.isDeleted == false).Select(p => p.category.ID).ToList();
                    bool check = true;
                    foreach(int Id in categoryIds)
                    {
                        if(tmpt.IndexOf(Id) == -1)
                        {
                            check = false;
                            break;
                        }
                    }
                    if(check)
                    {
                        lstTmpt.Add(item);
                    }
                }
                listProblems = lstTmpt;
            }

            if(minDifficult != null || maxDifficult != null)
            {
                if(minDifficult != null)
                {
                    listProblems = listProblems.Where(p => p.difficulty >= minDifficult).ToList();
                    paramater.Add("minDifficult", minDifficult.ToString());
                }
                if(maxDifficult != null)
                {
                    listProblems = listProblems.Where(p => p.difficulty <= maxDifficult).ToList();
                    paramater.Add("maxDifficult", maxDifficult.ToString());
                }
            }
            if(hideSolvedProblem)
            {
                listProblems = listProblems.Where(p => p.submissions.Where(s => s.status == "Accepted").ToList().Count() == 0).ToList();
                paramater.Add("hideSolvedProblem", hideSolvedProblem.ToString());
            }

            ViewBag.paginationParams = paramater;

            ViewData["SearchProblemInfor"] = new SearchProblemInfor
            {
                problemName = problemName,
                minDifficult = minDifficult,
                maxDifficult = maxDifficult,
                hideSolvedProblem = hideSolvedProblem
            };


            if(!HttpContext.User.Identity.IsAuthenticated || HttpContext.User.Claims.FirstOrDefault(p => p.Type == "Role").Value == "User")
            {
                listProblems = listProblems.Where(p => p.isPublic == true).Select(p => p).ToList();
            }

            //pagination
            if(page == null)
            {
                page = 1;
            }

            int limit = Utility.limitData;
            int start = (int)(page - 1)*limit;

            ViewBag.currentPage = page;

            ViewBag.totalPage = (int)Math.Ceiling((float)listProblems.Count/limit);

            listProblems = listProblems.Skip(start).Take(limit).ToList();

            return View(listProblems.ToList());
        }
        [Authorize(Roles ="Admin, Author")]
        public IActionResult AddProblem()
        {
            ViewData["listAuthors"] = _context.Accounts.Where(p => (p.roleID == 2 || p.roleID == 1) && p.isActived == true && p.isDeleted == false).OrderBy(p => p.accountName).ToList();

            ViewData["listCategories"] = _context.Categories.Where(p => p.isDeleted == false).OrderBy(p => p.name).ToList();

            return View();
        }
        [Authorize(Roles ="Admin, Author")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProblem([Bind("code, title, content, difficulty, timeLimit, memoryLimit, isPublic")] Problem reqProblem, List<int> reqListAuthorIds, List<int> reqListCategoryIds, string next)
        {
            ViewData["ListAuthors"] = _context.Accounts.Where(p => (p.roleID == 2 || p.roleID == 1) && p.isActived == true && p.isDeleted == false).OrderBy(p => p.accountName).ToList();

            ViewData["ListCategories"] = _context.Categories.Where(p => p.isDeleted == false).OrderBy(p => p.name).ToList();

            ViewData["ListChosenAuthorIds"] = reqListAuthorIds;

            ViewData["ListChosenCategoryIds"] = reqListCategoryIds;

            if (ModelState.IsValid)
            {
                if(reqListAuthorIds.Count == 0)
                {
                    ModelState.AddModelError("", "Bạn cần chọn tác giả");
                    return View();
                }
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

                _context.Add(reqProblem);

                var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);

                var action = new PBL3.Models.Action()
                {
                    account = _context.Accounts.FirstOrDefault(p => p.ID == accountID),
                    objectID = reqProblem.ID,
                    dateTime = DateTime.Now,
                    action = "Tạo mới",
                    typeObject = Convert.ToInt32(TypeObject.Problem)
                };

                await _context.SaveChangesAsync();

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

            ViewData["ListComments"] = _context.Comments.Where(p => p.postID == id && p.level == 1)
                                                        .Include(p => p.account)
                                                        .Include(p => p.child)
                                                        .Include(p => p.likes)
                                                        .ThenInclude(p => p.account).AsSplitQuery().OrderByDescending(p => p.timeCreate)
                                                        .ToList();
            if(problem == null)
            {
                return NotFound();
            }
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
            return View(problem);
        }
        [Authorize(Roles ="Admin, Author")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProblem(int id)
        {
            var problem = _context.Problems.Where(p => p.ID == id)
                                            .Include(p => p.submissions)
                                            .FirstOrDefault();

            if(problem == null)
                return NotFound();

            problem.isDeleted = true;

            foreach(var item in problem.submissions)
            {
                item.isDeleted = true;
                _context.Update(item);
            }

            _context.Update(problem);

            var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);

            _context.Add(new PBL3.Models.Action()
            {
                account = _context.Accounts.FirstOrDefault(p => p.ID == accountID),
                objectID = problem.ID,
                dateTime = DateTime.Now,
                action = "Xóa bài tập",
                typeObject = Convert.ToInt32(TypeObject.Problem)
            });

            await _context.SaveChangesAsync();
            
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

            ViewData["ListCategories"] = _context.Categories.Where(p => p.isDeleted == false).OrderBy(p => p.name).ToList();

            ViewData["ListChosenAuthorIds"] = problem.problemAuthors.Where(p => p.isDeleted == false).Select(p => p.authorID).ToList();

            ViewData["ListChosenCategoryIds"] = problem.problemClassifications.Where(p => p.isDeleted == false).Select(p => p.categoryID).ToList();

            ViewBag.problemTestCases = _context.TestCases.Where(p => p.problemID == id && p.isDeleted == false).ToList();

            return View(problem);
        }
        [Authorize(Roles ="Admin, Author")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProblem(int id, [Bind("code, title, content, difficulty, isPublic, timeLimit, memoryLimit")] Problem reqProblem, List<int> reqListAuthorIds, List<int> reqListCategoryIds, string next)
        {
            if(_context.Problems.FirstOrDefault(p => p.ID == id) == null)
            {
                return NotFound();
            }
            ViewData["ListAuthors"] = _context.Accounts.Where(p => (p.roleID == 2 || p.roleID == 1) && p.isDeleted == false && p.isActived == true).OrderBy(p => p.accountName).ToList();

            ViewData["ListCategories"] = _context.Categories.Where(p => p.isDeleted == false).OrderBy(p => p.name).ToList();

            ViewData["ListChosenAuthorIds"] = reqListAuthorIds;

            ViewData["ListChosenCategoryIds"] = reqListCategoryIds;

            if(ModelState.IsValid)
            {
                var problem =  _context.Problems.Include(p => p.problemAuthors)
                                                .Include(p => p.problemClassifications)
                                                .AsSplitQuery().OrderBy(p => p.title)
                                                .FirstOrDefault(p => p.ID == id);
                
                var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);

                var account = _context.Accounts.FirstOrDefault(p => p.ID == accountID);

                if(problem.code != reqProblem.code)
                {
                    problem.code = reqProblem.code;
                    var action = new PBL3.Models.Action()
                    {
                        account = account,
                        objectID = problem.ID,
                        dateTime = DateTime.Now,
                        action = "Sửa mã bài",
                        typeObject = Convert.ToInt32(TypeObject.Problem)
                    };
                    _context.Add(action);
                }

                if(problem.title != reqProblem.title)
                {
                    problem.title = reqProblem.title;
                    var action = new PBL3.Models.Action()
                    {
                        account = account,
                        objectID = problem.ID,
                        dateTime = DateTime.Now,
                        action = "Sửa tên bài",
                        typeObject = Convert.ToInt32(TypeObject.Problem)
                    };
                    _context.Add(action);
                }

                if(problem.content != reqProblem.content)
                {
                    problem.content = reqProblem.content;
                    var action = new PBL3.Models.Action()
                    {
                        account = account,
                        objectID = problem.ID,
                        dateTime = DateTime.Now,
                        action = "Sửa đề bài",
                        typeObject = Convert.ToInt32(TypeObject.Problem)
                    };
                    _context.Add(action);
                }

                if(problem.difficulty != reqProblem.difficulty)
                {
                    problem.difficulty = reqProblem.difficulty;
                    var action = new PBL3.Models.Action()
                    {
                        account = account,
                        objectID = problem.ID,
                        dateTime = DateTime.Now,
                        action = "Sửa độ khó",
                        typeObject = Convert.ToInt32(TypeObject.Problem)
                    };
                    _context.Add(action);
                }

                if(problem.isPublic != reqProblem.isPublic)
                {
                    problem.isPublic = reqProblem.isPublic;
                    var action = new PBL3.Models.Action()
                    {
                        account = account,
                        objectID = problem.ID,
                        dateTime = DateTime.Now,
                        action = "Sửa trạng thái bài",
                        typeObject = Convert.ToInt32(TypeObject.Problem)
                    };
                    _context.Add(action);
                }

                if(problem.timeLimit != reqProblem.timeLimit)
                {
                    problem.timeLimit = reqProblem.timeLimit;
                    var action = new PBL3.Models.Action()
                    {
                        account = account,
                        objectID = problem.ID,
                        dateTime = DateTime.Now,
                        action = "Sửa thời gian giới hạn",
                        typeObject = Convert.ToInt32(TypeObject.Problem)
                    };
                    _context.Add(action);
                }

                if(problem.memoryLimit != reqProblem.memoryLimit)
                {
                    problem.memoryLimit = reqProblem.memoryLimit;
                    var action = new PBL3.Models.Action()
                    {
                        account = account,
                        objectID = problem.ID,
                        dateTime = DateTime.Now,
                        action = "Sửa giới hạn bộ nhớ",
                        typeObject = Convert.ToInt32(TypeObject.Problem)
                    };
                    _context.Add(action);
                }
                
                var listProblemAuthors = problem.problemAuthors.Where(p => p.isDeleted == false).ToList();

                if(Utility.DifferentList(reqListAuthorIds, listProblemAuthors.Select(p => p.authorID).ToList()))
                {
                    var action = new PBL3.Models.Action()
                    {
                        account = account,
                        objectID = problem.ID,
                        dateTime = DateTime.Now,
                        action = "Sửa tác giả",
                        typeObject = Convert.ToInt32(TypeObject.Problem)
                    };
                    _context.Add(action);
                }

                foreach(var item in listProblemAuthors)// old listProblemAuthors     new reqListAuthorIds
                {
                    //delete
                    if(reqListAuthorIds.Any(p => p == item.authorID) == false)
                    {
                        item.isDeleted = true;
                        _context.Update(item);
                    }
                }
                foreach(var item in reqListAuthorIds)
                {
                    //add
                    if(listProblemAuthors.Any(p => p.authorID == item) == false)
                    {
                        _context.Add(new ProblemAuthor()
                        {
                            authorID = item,
                            problem = problem
                        });
                    }
                    else
                    {
                        var tmpt = problem.problemAuthors.FirstOrDefault(p => p.authorID == item);
                        tmpt.isDeleted = false;
                        _context.Update(tmpt);
                    }
                }

                var listProblemClassifications = problem.problemClassifications.Where(p => p.isDeleted == false).ToList();

                if(Utility.DifferentList(reqListCategoryIds, listProblemClassifications.Select(p => p.categoryID).ToList()))
                {
                    var action = new PBL3.Models.Action()
                    {
                        account = account,
                        objectID = problem.ID,
                        dateTime = DateTime.Now,
                        action = "Sửa dạng bài",
                        typeObject = Convert.ToInt32(TypeObject.Problem)
                    };
                    _context.Add(action);
                }

                foreach(var item in listProblemClassifications)
                {
                    //delete
                    if(reqListCategoryIds.Any(p => p == item.categoryID) == false)
                    {
                        item.isDeleted= true;
                        _context.Update(item);
                    }
                }
                foreach(var item in reqListCategoryIds)
                {
                    //add
                    if(listProblemClassifications.Any(p => p.categoryID == item) == false)
                    {
                        _context.Add(new ProblemClassification()
                        {
                            categoryID = item,
                            problem = problem
                        });
                    }
                    else
                    {
                        var tmpt = problem.problemClassifications.FirstOrDefault(p => p.categoryID == item);
                        tmpt.isDeleted = false;
                        _context.Update(tmpt);
                    }
                }

                _context.Update(problem);
                await _context.SaveChangesAsync();
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
            var problem = _context.Problems.FirstOrDefault(p => p.ID == id);
            if(problem == null)
            {
                return NotFound();
            }
            var listActions = _context.Actions.Where(p => p.objectID == id && p.typeObject == Convert.ToInt32(TypeObject.Problem)).Include(p => p.account).OrderByDescending(p => p.dateTime).ToList();
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

            foreach(var item in problem.submissions)
            {
                item.isDeleted = false;
                _context.Update(item);
            }

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
