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
using PBL3.Features.ProblemManagement;
using PBL3.Features.ActionManagemant;
using PBL3.Features.AccountManagement;
using PBL3.Repositories;
namespace PBL3.Features.CategoryManagement
{
    [Authorize(Roles ="Admin, Author")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProblemService _problemService;
        private readonly IActionService _actionService;
        private readonly IAccountService _accountService;
        private readonly IRepository<ProblemClassification> _problemClassficationRepo;
        public CategoriesController(ICategoryService categoryService, IProblemService problemService, IActionService actionService,
            IAccountService accountService, IRepository<ProblemClassification> problemClassficationRepo)
        {
            _categoryService = categoryService;
            _problemService = problemService;
            _actionService = actionService;
            _accountService = accountService;
            _problemClassficationRepo = problemClassficationRepo;
        }
        public IActionResult AddProblemCategory()
        {
            ViewData["ListProblems"] = _problemService.GetAllProblems().ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProblemCategory([Bind("name")] Category reqCategory, List<int> reqListProblemIds)
        {
            ViewData["ListProblems"] = _problemService.GetAllProblems().ToList();
            ViewData["ListChosenProblemIDs"] = reqListProblemIds;

            if(ModelState.IsValid)
            {
                var category = _categoryService.GetCategoriesByName(reqCategory.name).FirstOrDefault();
                if(category != null)
                {
                    ModelState.AddModelError("", "Dạng bài đã tồn tại !");
                    return View();
                }
                _categoryService.AddCategory(category);

                foreach(int id in reqListProblemIds)
                {
                    var problemClassification = new ProblemClassification()
                    {
                        problemID = id,
                        category = reqCategory
                    };
                    _problemClassficationRepo.Insert(problemClassification);
                }

                var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);
                _actionService.AddAction(new PBL3.Models.Action()
                {
                    account = _accountService.GetAccountByID(accountID),
                    objectID = reqCategory.ID,
                    dateTime = DateTime.Now,
                    action = "Tạo mới",
                    typeObject = Convert.ToInt32(TypeObject.ProblemCategory)
                });
                return RedirectToAction("ProblemCategories", "Admin");
            }
            return View();
        }
        public IActionResult EditProblemCategory(int id)
        {
            ViewData["ListProblems"] = _problemService.GetAllProblems().ToList();

            ViewData["ListChosenProblemIds"] = _problemClassficationRepo.GetAll()
            .Where(p => p.categoryID == id && p.isDeleted == false)
            .Select(p => p.problemID).ToList();

            var problemCategory = _categoryService.GetCategoryByID(id);
            return View(problemCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProblemCategory(int id, [Bind("name")] Category reqCategory, List<int> reqListProblemIds)
        {
            ViewData["ListProblems"] = _problemService.GetAllProblems().ToList();
            ViewData["ListChosenProblemIds"] = reqListProblemIds.ToList();

            if(ModelState.IsValid)
            {
                var problemCategory = _categoryService.GetCategoryByID(id);
                if(problemCategory == null)
                    return NotFound();
                if(problemCategory.name != reqCategory.name && _categoryService.GetCategoryByName(reqCategory.name) != null)
                {
                    ModelState.AddModelError("", "Dạng bài đã tồn tại");
                    return View(reqCategory);
                }

                var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);
                var listProblemClassifications = _problemClassficationRepo.GetAll()
                .Where(pc => pc.categoryID == id && pc.isDeleted == false).ToList();

                // var lstTmpt = new List<ProblemClassification>();

                // lstTmpt.AddRange(listProblemClassifications.Select(pc => pc));

                if(Utility.DifferentList(reqListProblemIds, listProblemClassifications.Select(p => p.problemID).ToList()))
                {
                    _actionService.AddAction(new PBL3.Models.Action()
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
                        _problemClassficationRepo.Update(item);
                    }
                }
                foreach(var item in reqListProblemIds)
                {
                    //them
                    if(listProblemClassifications.Any(p => p.problemID == item) == false)
                    {
                        _problemClassficationRepo.Insert(new ProblemClassification()
                        {
                            problemID = item,
                            categoryID = id
                        });
                    }
                    else
                    {
                        var tmpt = listProblemClassifications.FirstOrDefault(p => p.problemID == item);
                        tmpt.isDeleted = false;
                        _problemClassficationRepo.Update(tmpt);
                    }
                }

                if(problemCategory.name != reqCategory.name)
                {
                    problemCategory.name = reqCategory.name;
                    _actionService.AddAction(new PBL3.Models.Action()
                    {
                        accountID = accountID,
                        objectID = id,
                        dateTime = DateTime.Now,
                        action = "Sửa tên dạng bài",
                        typeObject = Convert.ToInt32(TypeObject.ProblemCategory)
                    });
                }
                _categoryService.UpdateCategory(problemCategory);

                // _context.ProblemClassifications.RemoveRange(listProblemClassifications);
                // _context.AddRange(lstTmpt);
                return RedirectToAction("ProblemCategories", "Admin");
            }

            return View(reqCategory);
        }
        public IActionResult History(int id)
        {
            var problemCategory = _categoryService.GetCategoryByID(id);
            if(problemCategory == null)
            {
                return NotFound();
            }
            var listActions = _actionService.GetActionsByObject(problemCategory.ID, (int)TypeObject.ProblemCategory)
            .OrderByDescending(p => p.dateTime).ToList();
            List<PBL3.Models.Action> listActionsIncludeAccount = new List<PBL3.Models.Action>();
            foreach(PBL3.Models.Action item in listActions)
            {
                item.account = _accountService.GetAccountByID(item.accountID);
                listActionsIncludeAccount.Add(item);
            }
            return View(listActionsIncludeAccount);
        }
        public IActionResult DeleteProblemCategory(int id)
        {
            var problemCategory = _categoryService.GetCategoryByID(id);
            if(problemCategory == null)
            {
                return NotFound();
            }

            ViewData["ListProblems"] = _problemService.GetAllProblems().ToList();

            ViewData["ListChosenProblemIds"] = _problemClassficationRepo.GetAll()
            .Where(p => p.categoryID == id && p.isDeleted == false)
            .Select(p => p.problemID).ToList();

            return View(problemCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProblemCategory(int? id)
        {
            var problemCategory = _categoryService.GetCategoryByID((int)id);
            if(problemCategory == null)
            {
                return NotFound();
            }

            problemCategory.isDeleted = true;
            
            var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);

            _actionService.AddAction(new PBL3.Models.Action()
            {
                account = _accountService.GetAccountByID(accountID),
                objectID = problemCategory.ID,
                dateTime = DateTime.Now,
                action = "Xóa dạng bài",
                typeObject = Convert.ToInt32(TypeObject.ProblemCategory)
            });
            return RedirectToAction("ProblemCategories", "Admin");
        }
        public IActionResult DeletedProblemCategories()
        {
            var listDates = new List<DateTime>();
            var deletedCategories = _categoryService.GetAllDeletedCategories().ToList();
            foreach(var item in deletedCategories)
            {
                var action = _actionService.GetActionsByObject(item.ID, (int)TypeObject.ProblemCategory)
                .OrderByDescending(p => p.dateTime).First();
                listDates.Add(action.dateTime);
            }
            ViewBag.deleteDates = listDates;
            return View(deletedCategories);
        }
        public IActionResult RestoreProblemCategory(int id)
        {
            var category = _categoryService.GetCategoryByID(id);

            if(category == null)
            {
                return NotFound();
            }
            ViewData["ListProblems"] = _problemService.GetAllProblems().ToList();

            ViewData["ListChosenProblemIds"] = _problemClassficationRepo.GetAll()
            .Where(p => p.categoryID == id && p.isDeleted == false).Select(p => p.problemID).ToList();
            return View(category); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RestoreProblemCategory(int? id)
        {
            var category = _categoryService.GetCategoryByID((int)id);

            if(category == null)
            {
                return NotFound();
            }
            category.isDeleted = false;
            _categoryService.UpdateCategory(category);
            var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);
            _actionService.AddAction(new PBL3.Models.Action()
            {
                account = _accountService.GetAccountByID(accountID),
                objectID = category.ID,
                dateTime = DateTime.Now,
                action = "Khôi phục dạng bài",
                typeObject = Convert.ToInt32(TypeObject.ProblemCategory)
            });
            return RedirectToAction("ProblemCategories", "Admin");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
