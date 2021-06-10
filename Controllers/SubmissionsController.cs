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
using Microsoft.AspNetCore.Authorization;

namespace PBL3.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly PBL3Context _context;
        public SubmissionsController(PBL3Context context)
        {
            _context = context;
        }
        public IActionResult Index(int? page)
        {
            var listSubmissions = _context.Submissions.Where(p => p.isDeleted == false).Include(p => p.account).Include(p => p.problem).OrderByDescending(p => p.timeCreate).ToList();
            if(page == null)
            {
                page = 1;
            }

            int limit = Utility.limitData;
            int start = (int)(page - 1)*limit;

            ViewBag.currentPage = page;

            ViewBag.totalPage = (int)Math.Ceiling((float)listSubmissions.Count/limit);

            listSubmissions = listSubmissions.Skip(start).Take(limit).OrderByDescending(p => p.timeCreate).ToList();
            
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
        public IActionResult GetSubmission(int? id)
        {
            var submission  = _context.Submissions.Include(s => s.account)
                                                .Include(s => s.problem)
                                                .Include(s => s.submissionResults)
                                                .ThenInclude(sr => sr.testCase)
                                                .FirstOrDefault(s => s.ID == id);
            return View(submission);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult EditSubmission(int id)
        {
            var submission = _context.Submissions.Include(p => p.problem).Include(p => p.account).Include(p => p.submissionResults).FirstOrDefault(p => p.ID == id);

            if(submission == null)
            {
                return NotFound();
            }

            return View(submission);
        }
        [Authorize(Roles = "Admin")]
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
