using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PBL3.Models;
using PBL3.Data;
using Microsoft.EntityFrameworkCore;
using PBL3.General;
using Microsoft.AspNetCore.Authorization;

namespace PBL3.Controllers
{
    [Authorize(Roles ="Admin, Author")]
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
        public IActionResult Problems(int? page, int authorId, int? isPublic, string searchText)
        {
            ViewData["ListAuthors"] = _context.Accounts.Where(p => p.roleID == 2 || p.roleID == 1).OrderBy(p => p.accountName).ToList();
            
            var listProblems = _context.Problems.Include(p => p.problemAuthors)
                                                .ThenInclude(p => p.author)
                                                .Where(p => p.isDeleted == false)
                                                .OrderByDescending(p => p.timeCreate)
                                                .ToList();
            var paramater = new Dictionary<string, string>();
            if(authorId != 0)
            {
                listProblems =  listProblems.Where(p => p.problemAuthors.Select(p => p.authorID).ToList().Contains(authorId))
                                            .ToList();
                paramater.Add("authorId", authorId.ToString());
            }

            if(isPublic != null)
            {
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
                paramater.Add("isPublic", isPublic.ToString());
            }

            if(!String.IsNullOrEmpty(searchText))
            {
                listProblems =  listProblems.Where(problem => problem.title.ToLower().Contains(searchText.ToLower()) || problem.code.ToLower().Contains(searchText.ToLower()))
                                            .ToList();
                paramater.Add("searchText", searchText);
            }

            ViewBag.paginationParams = paramater;

            if(page == null)
            {
                page = 1;
            }
            
            int limit = Utility.limitData;

            int start = (int)(page - 1)*limit;

            ViewBag.currentPage = page;

            ViewBag.totalPage = (int)Math.Ceiling((float)listProblems.Count/limit);

            listProblems = listProblems.Skip(start).Take(limit).ToList();

            return View(listProblems);
        }
        public IActionResult ProblemCategories(int? page, string categoryName)
        {
            var listProblemCategories = _context.Categories.Where(p => p.isDeleted == false).ToList();

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
        [Authorize(Roles = "Admin")]
        public IActionResult Submissions(int? page, string language, string status, string searchText)
        {
            var listSubmissions = _context.Submissions.Where(p => p.isDeleted == false).Include(p => p.problem).Include(p => p.account).OrderByDescending(p => p.timeCreate).ToList();
            
            var paramater = new Dictionary<string, string>();

            if(language != "all" && !string.IsNullOrEmpty(language))
            {
                listSubmissions = listSubmissions.Where(p => p.language == language).ToList();
                paramater.Add("language", language);
            }
            
            if(status != "all" && !string.IsNullOrEmpty(status))
            {
                listSubmissions = listSubmissions.Where(p => p.status == status).ToList();
                paramater.Add("status", status);
            }
            
            if(!string.IsNullOrEmpty(searchText))
            {
                listSubmissions = listSubmissions.Where(p => p.problem.title.ToLower().Contains(searchText.ToLower()) || p.problem.code.ToLower().Contains(searchText.ToLower()) || p.account.accountName.ToLower().Contains(searchText.ToLower())).ToList();
                paramater.Add("searchText", searchText);
            }

            ViewBag.paginationParams = paramater;
            
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
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
