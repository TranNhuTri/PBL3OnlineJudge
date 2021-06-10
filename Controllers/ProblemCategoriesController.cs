using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using PBL3.Models;
using PBL3.Data;
using PBL3.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace PBL3.Controllers
{
    [Authorize(Roles ="Admin, Author")]
    public class ProblemCategoriesController : Controller
    {
        private readonly PBL3Context _context;
        public ProblemCategoriesController(PBL3Context context)
        {
            _context = context;
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

                await _context.SaveChangesAsync();

                foreach(int id in reqListProblemIds)
                {
                    var problemClassification = new ProblemClassification()
                    {
                        problemID = id,
                        category = reqCategory
                    };
                    _context.Add(problemClassification);
                }

                var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);

                _context.Add(new PBL3.Models.Action()
                {
                    account = _context.Accounts.FirstOrDefault(p => p.ID == accountID),
                    objectID = reqCategory.ID,
                    dateTime = DateTime.Now,
                    action = "Tạo mới",
                    typeObject = Convert.ToInt32(TypeObject.ProblemCategory)
                });

                await _context.SaveChangesAsync();

                return RedirectToAction("ProblemCategories", "Admin");
            }
            return View();
        }
        public IActionResult EditProblemCategory(int id)
        {
            ViewData["ListProblems"] = _context.Problems.Where(p => p.isDeleted == false).ToList();

            ViewData["ListChosenProblemIds"] = _context.ProblemClassifications.Where(p => p.categoryID == id && p.isDeleted == false).Select(p => p.problemID).ToList();

            var problemCategory = _context.Categories.FirstOrDefault(p =>p .ID == id);

            return View(problemCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProblemCategory(int id, [Bind("name")] Category reqCategory, List<int> reqListProblemIds)
        {
            ViewData["ListProblems"] = _context.Problems.Where(p => p.isDeleted == false).ToList();

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

                var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);

                var listProblemClassifications = _context.ProblemClassifications.Where(pc => pc.categoryID == id && pc.isDeleted == false).ToList();

                // var lstTmpt = new List<ProblemClassification>();

                // lstTmpt.AddRange(listProblemClassifications.Select(pc => pc));

                if(Utility.DifferentList(reqListProblemIds, listProblemClassifications.Select(p => p.problemID).ToList()))
                {
                    _context.Add(new PBL3.Models.Action()
                    {
                        accountID = accountID,
                        objectID = id,
                        dateTime = DateTime.Now,
                        action = "Sửa danh sách bài tập",
                        typeObject = Convert.ToInt32(TypeObject.ProblemCategory)
                    });
                }

                foreach(var item in listProblemClassifications)
                {
                    //xoa
                    if(reqListProblemIds.Any(p => p == item.problemID) == false)
                    {
                        item.isDeleted = true;
                        _context.Update(item);
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
                    else
                    {
                        var tmpt = listProblemClassifications.FirstOrDefault(p => p.problemID == item);
                        tmpt.isDeleted = false;
                        _context.Update(tmpt);
                    }
                }

                if(problemCategory.name != reqCategory.name)
                {
                    problemCategory.name = reqCategory.name;
                    _context.Add(new PBL3.Models.Action()
                    {
                        accountID = accountID,
                        objectID = id,
                        dateTime = DateTime.Now,
                        action = "Sửa tên dạng bài",
                        typeObject = Convert.ToInt32(TypeObject.ProblemCategory)
                    });
                }
                _context.Update(problemCategory);

                // _context.ProblemClassifications.RemoveRange(listProblemClassifications);

                // _context.AddRange(lstTmpt);

                await _context.SaveChangesAsync();

                return RedirectToAction("ProblemCategories", "Admin");
            }

            return View(reqCategory);
        }
        public IActionResult History(int id)
        {
            var problemCategory = _context.Categories.FirstOrDefault(p => p.ID == id);
            if(problemCategory == null)
            {
                return NotFound();
            }
            var listActions = _context.Actions.Where(p => p.objectID == problemCategory.ID && p.typeObject == Convert.ToInt32(TypeObject.ProblemCategory)).Include(p => p.account).OrderByDescending(p => p.dateTime).ToList();
            return View(listActions);
        }
        public IActionResult DeleteProblemCategory(int id)
        {
            var problemCategory = _context.Categories.Where(p => p.ID == id).FirstOrDefault();
            if(problemCategory == null)
            {
                return NotFound();
            }

            ViewData["ListProblems"] = _context.Problems.Where(p => p.isDeleted == false).ToList();

            ViewData["ListChosenProblemIds"] = _context.ProblemClassifications.Where(p => p.categoryID == id && p.isDeleted == false).Select(p => p.problemID).ToList();

            return View(problemCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProblemCategory(int? id)
        {
            var problemCategory = _context.Categories.Where(p => p.ID == id).FirstOrDefault();
            if(problemCategory == null)
            {
                return NotFound();
            }

            problemCategory.isDeleted = true;
            
            var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);

            _context.Add(new PBL3.Models.Action()
            {
                account = _context.Accounts.FirstOrDefault(p => p.ID == accountID),
                objectID = problemCategory.ID,
                dateTime = DateTime.Now,
                action = "Xóa dạng bài",
                typeObject = Convert.ToInt32(TypeObject.ProblemCategory)
            });

            _context.SaveChanges();

            return RedirectToAction("ProblemCategories", "Admin");
        }
        public IActionResult DeletedProblemCategories()
        {
            var listDates = new List<DateTime>();

            var deletedCategories = _context.Categories.Where(p => p.isDeleted == true).ToList();

            foreach(var item in deletedCategories)
            {
                var action = _context.Actions.Where(p => p.objectID == item.ID && p.typeObject == (int)TypeObject.ProblemCategory).OrderByDescending(p => p.dateTime).First();
                listDates.Add(action.dateTime);
            }
            
            ViewBag.deleteDates = listDates;

            return View(_context.Categories.Where(p => p.isDeleted == true).ToList());
        }
        public IActionResult RestoreProblemCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(p => p.ID == id);

            if(category == null)
            {
                return NotFound();
            }
            ViewData["ListProblems"] = _context.Problems.Where(p => p.isDeleted == false).ToList();

            ViewData["ListChosenProblemIds"] = _context.ProblemClassifications.Where(p => p.categoryID == id && p.isDeleted == false).Select(p => p.problemID).ToList();

            return View(category); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RestoreProblemCategory(int? id)
        {
            var category = _context.Categories.FirstOrDefault(p => p.ID == id);

            if(category == null)
            {
                return NotFound();
            }
            category.isDeleted = false;

            _context.Update(category);

            var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);

            _context.Add(new PBL3.Models.Action()
            {
                account = _context.Accounts.FirstOrDefault(p => p.ID == accountID),
                objectID = category.ID,
                dateTime = DateTime.Now,
                action = "Khôi phục dạng bài",
                typeObject = Convert.ToInt32(TypeObject.ProblemCategory)
            });

            _context.SaveChanges();

            return RedirectToAction("ProblemCategories", "Admin");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
