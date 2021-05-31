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

namespace PBL3.Controllers
{
    public class ListProblemsController : Controller
    {
        private readonly PBL3Context _context;
        public ListProblemsController(PBL3Context context)
        {
            _context = context;
        }
        public IActionResult Index(int? id, string problemName, bool hideSolvedProblem, List<int> listCategoryIds, int? minDifficult, int? maxDifficult)
        {
            ViewData["listCategories"] = _context.Categories.ToList();

            var listProblems = _context.Problems.Include(p => p.problemClassifications)
                                                .Include(p => p.submissions)
                                                .ThenInclude(s => s.account).AsSplitQuery().OrderByDescending(p => p.timeCreate)
                                                .ToList();
            
            if(!String.IsNullOrEmpty(problemName))
            {
                listProblems = listProblems.Where(p => p.title.ToLower().Contains(problemName.ToLower())).ToList();
            }
            
            if(listCategoryIds.Count > 0)
            {
                var lstTmpt = new List<Problem>();
                foreach(var item in listProblems)
                {
                    var tmpt = item.problemClassifications.Select(p => p.category.ID).ToList();
                    bool check = true;
                    foreach(int Id in listCategoryIds)
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
                }
                if(maxDifficult != null)
                {
                    listProblems = listProblems.Where(p => p.difficulty <= maxDifficult).ToList();
                }
            }
            if(hideSolvedProblem)
            {
                listProblems = listProblems.Where(p => p.submissions.Where(s => s.status == "Accepted").ToList().Count() == 0).ToList();
            }
            ViewData["SearchProblemInfor"] = new SearchProblemInfor
            {
                problemName = problemName,
                minDifficult = minDifficult,
                maxDifficult = maxDifficult,
                hideSolvedProblem = hideSolvedProblem
            };
            if(string.IsNullOrEmpty(HttpContext.Session.GetString("TypeAccount")) || Convert.ToInt32(HttpContext.Session.GetString("typeAccount")) == 3)
            {
                listProblems = listProblems.Where(p => p.isPublic == true).Select(p => p).ToList();
            }

            //pagination
            int page;
            if(id == null)
            {
                page = 1;
            }
            else
            {
                page = (int)id;
            }
            int limit = Utility.limitData;
            int start = (int)(page - 1)*limit;

            ViewBag.currentPage = page;

            ViewBag.totalPage = (int)Math.Ceiling((float)listProblems.Count/limit);

            listProblems = listProblems.Skip(start).Take(limit).ToList();

            return View(listProblems.ToList());
        }
        public IActionResult Add()
        {
            ViewData["listAuthors"] = _context.Accounts.Where(p => p.typeAccount == 2 || p.typeAccount == 1).OrderBy(p => p.accountName).ToList();

            ViewData["listCategories"] = _context.Categories.OrderBy(p => p.name).ToList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("code, title, content, difficulty, timeLimit, memoryLimit, isPublic")] Problem reqProblem, List<int> reqListAuthorIds, List<int> reqListCategorieIds, string next)
        {
            ViewData["ListAuthors"] = _context.Accounts.Where(p => p.typeAccount == 2 || p.typeAccount == 1).OrderBy(p => p.accountName).ToList();

            ViewData["ListCategories"] = _context.Categories.OrderBy(p => p.name).ToList();

            ViewData["ListChosenAuthorIds"] = reqListAuthorIds;

            ViewData["ListChosenCategoryIds"] = reqListCategorieIds;

            if (ModelState.IsValid)
            {
                if(reqListAuthorIds.Count == 0)
                {
                    ModelState.AddModelError("", "Bạn cần chọn tác giả");
                    return View();
                }
                if(reqListCategorieIds.Count == 0)
                {
                    ModelState.AddModelError("", "Bạn cần chọn dạng bài");
                    return View();
                }
                if(_context.Problems.FirstOrDefault(p => p.code == reqProblem.code) != null)
                {
                    ModelState.AddModelError("", "Mã bài đã tồn tại");
                    return View();
                }
                if(_context.Problems.FirstOrDefault(p => p.title == reqProblem.title) != null)
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
                foreach(int id in reqListCategorieIds)
                { 
                    _context.Add(new ProblemClassification()
                    {
                        problem = reqProblem,
                        categoryID = id
                    });
                }
                _context.Add(reqProblem);

                await _context.SaveChangesAsync();

                if(next == "edit")
                {
                    return RedirectToAction("Edit", "Problem", new {id = reqProblem.ID});
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Problem(int id)
        {
            var problem = _context.Problems.Include(p => p.problemAuthors)
                                            .ThenInclude(p => p.author)
                                            .Include(p => p.problemClassifications)
                                            .ThenInclude(p => p.category)
                                            .Include(p => p.submissions)
                                            .ThenInclude(s => s.account)
                                            .AsSplitQuery()
                                            .OrderByDescending(p => p.timeCreate)
                                            .FirstOrDefault(p => p.ID == id);
            ViewData["ListComments"] = _context.Comments.Where(p => p.postID == id && p.level == 1)
                                                        .Include(p => p.account)
                                                        .Include(p => p.child)
                                                        .ToList();
            if(problem == null)
            {
                return NotFound();
            }
            return View(problem);
        }
        public IActionResult Delete(int? id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var problem = _context.Problems.FirstOrDefault(p => p.ID == id);

            if(problem == null)
                return NotFound();

            problem.isDeleted = true;
            _context.Update(problem);

            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
