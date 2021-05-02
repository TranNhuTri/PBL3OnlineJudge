using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PBL3.Models;
using PBL3.Data;

namespace PBL3.Controllers
{
    public class ProblemController : Controller
    {
        private readonly PBL3Context _context;
        public ProblemController(PBL3Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Submit(string id)
        {
            var problem = _context.Problem.FirstOrDefault(m => m.ID == id);
            return View(problem);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Submit(string id, string ProblemSolution, string Language)
        {
            var problem = _context.Problem.FirstOrDefault(p => p.ID == id);
            var submission = new Submission
            {
                Code = ProblemSolution,
                Language = Language,
                DateSubmit = DateTime.Now,
                Status = "Running",
                ProblemID = problem.ID,
                AccountID = 1
            };
            _context.Submission.Add(submission);
            _context.SaveChanges();
            return View("SubmitStatus", submission);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
class code
{
    public string script{get; set;}
    public string language {get; set;}
    public int versionIndex{get; set;}
    public string stdin{get; set;}
    public string clientId{get; set;} = "672651acf3fa819a1e0c27a9fb272658";
    public string clientSecret{get; set;} = "eb951e6e38f239380084104d7629f1312d66345ec661a4da5bd62822ad3a842b";
}
class SubmitResponse
{
    public string output{get; set;}
    public int statusCode{get; set;}
    public int memory{get; set;}
    public float cpuTime{get; set;}
}