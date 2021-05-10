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
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace PBL3.Controllers
{
    public class DataController : Controller
    {
        private readonly PBL3Context _context;
        public DataController(PBL3Context context)
        {
            _context = context;
        }
        public string Submission(int? id)
        {
            var submission = _context.Submission.Include(s => s.User).Include(s => s.Problem).Include(s => s.SubmissionResults).ThenInclude(sr => sr.TestCase).FirstOrDefault(s => s.ID == id);

            var submissionResponse = new SubmissionResponse()
            {
                ProblemTitle = submission.Problem.Title,
                UserName = submission.User.UserName,
                Code = submission.Code,
                SubmissionResults = submission.SubmissionResults,
                Status = submission.Status
            };
            return JsonConvert.SerializeObject(submissionResponse, new JsonSerializerSettings() { 
		        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
	        });
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    class SubmissionResponse
    {
        public string UserName{get; set;}
        public string ProblemTitle{get; set;}
        public string Code{get; set;}
        public List<SubmissionResult> SubmissionResults{get; set;}
        public string Status{get; set;}
    }
}
