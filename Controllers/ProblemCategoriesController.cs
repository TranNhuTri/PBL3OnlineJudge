using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PBL3.Models;
using PBL3.Data;
using Microsoft.EntityFrameworkCore;

namespace PBL3.Controllers
{
    public class ProblemCategoriesController : Controller
    {
        private readonly PBL3Context _context;
        public ProblemCategoriesController(PBL3Context context)
        {
            _context = context;
        }
        public IActionResult History(int id)
        {
            var problemCategory = _context.Categories.FirstOrDefault(p => p.ID == id);
            if(problemCategory == null)
            {
                return NotFound();
            }
            var listActions = _context.Actions.Where(p => p.objectID == problemCategory.ID).Include(p => p.account).OrderByDescending(p => p.dateTime).ToList();
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

            _context.Add(new PBL3.Models.Action()
            {
                account = _context.Accounts.FirstOrDefault(p => p.accountName == HttpContext.Session.GetString("AccountName")),
                objectID = problemCategory.ID,
                dateTime = DateTime.Now,
                action = "Xóa dạng bài"
            });

            _context.SaveChanges();

            return RedirectToAction("ProblemCategories", "Admin");
        }
        public IActionResult DeletedProblemCategories()
        {
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

            ViewData["ListChosenProblemIds"] = _context.ProblemClassifications.Where(p => p.categoryID == id && p.isDeleted == true).Select(p => p.problemID).ToList();

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

            _context.Add(new PBL3.Models.Action()
            {
                account = _context.Accounts.FirstOrDefault(p => p.accountName == HttpContext.Session.GetString("AccountName")),
                objectID = category.ID,
                dateTime = DateTime.Now,
                action = "Khôi phục dạng bài"
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
