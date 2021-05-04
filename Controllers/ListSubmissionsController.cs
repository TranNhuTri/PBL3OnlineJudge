using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PBL3.Models;
using PBL3.Data;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;
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
            var listSubmissions = from submission in _context.Submission select submission;
            return View(listSubmissions.ToList());
        }
        public IActionResult Submission(int? id)
        {
            if(id == null)
                return NotFound();
            var submission = _context.Submission.FirstOrDefault(s => s.ID == id);
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
