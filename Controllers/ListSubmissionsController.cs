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
    public class ListSubmissionsController : Controller
    {
        private readonly PBL3Context _context;
        public ListSubmissionsController(PBL3Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var listSubmissions = _context.Submissions.Include(p => p.account).Include(p => p.problem).ToList();
            
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
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
