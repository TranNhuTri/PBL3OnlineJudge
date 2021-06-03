using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PBL3.Models;
using PBL3.Data;
using Microsoft.EntityFrameworkCore;
using PBL3.General;
using Newtonsoft.Json;

namespace PBL3.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly PBL3Context _context;
        public SubmissionsController(PBL3Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Page));
        }
        public IActionResult Page(int? id)
        {
            var listSubmissions = _context.Submissions.Where(p => p.isDeleted == false).Include(p => p.account).Include(p => p.problem).OrderByDescending(p => p.timeCreate).ToList();
            int page = 1;
            if(id != null)
            {
                page = (int)id;
            }

            int limit = Utility.limitData;
            int start = (int)(page - 1)*limit;

            ViewBag.currentPage = page;

            ViewBag.totalPage = (int)Math.Ceiling((float)listSubmissions.Count/limit);

            listSubmissions = listSubmissions.Skip(start).Take(limit).ToList();
            
            return View(listSubmissions);
        }
        public IActionResult Submission(int? id)
        {
            if(id == null)
                return NotFound();

            var submission = _context.Submissions.FirstOrDefault(s => s.ID == id);

            if(submission == null)
                return NotFound();

            return View(submission);
        }
        public string GetSubmission(int? id)
        {
            var submission  = _context.Submissions.Include(s => s.account)
                                                .Include(s => s.problem)
                                                .Include(s => s.submissionResults)
                                                .ThenInclude(sr => sr.testCase)
                                                .Select(s => new{s.ID, s.account.accountName, s.problem.title, s.code, s.submissionResults, s.status, s.memory, s.time})
                                                .FirstOrDefault(s => s.ID == id);
            return JsonConvert.SerializeObject(submission, new JsonSerializerSettings() { 
		        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
	        });
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
