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

namespace PBL3.Controllers
{
    public class ProblemController : Controller
    {
        private readonly PBL3Context _context;
        public ProblemController(PBL3Context context)
        {
            _context = context;
        }
        public IActionResult Edit(string id)
        {
            var model = _context.Problem.FirstOrDefault(m => m.ID == id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID, Title, Content, Difficulty")] Problem problem)
        {
            if(id != problem.ID)
            {
                return NotFound();
            }
            var probl = _context.Problem.FirstOrDefault(m => m.ID == id);
            probl.Title = problem.Title;
            probl.Content = problem.Content;
            probl.Difficulty = problem.Difficulty;

            if (ModelState.IsValid && probl != null)
            {
                _context.Update(probl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Problem), "ListProblems", probl);
            }
            return View(problem);
        }
        public IActionResult Submit(string id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Console.WriteLine(HttpContext.Session.GetString("userName"));
            if(String.IsNullOrEmpty(HttpContext.Session.GetString("userName")))
            {
                return RedirectToAction("Login", "Account");
            }
            var problem = _context.Problem.FirstOrDefault(m => m.ID == id);
            if(problem == null)
            {
                return NotFound();
            }
            return View(problem);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Submit(string id, string ProblemSolution, string Language)
        {
            var problem = _context.Problem.FirstOrDefault(p => p.ID == id);
            var account = _context.Account.FirstOrDefault(a => a.ID == Convert.ToInt32(HttpContext.Session.GetString("accountID")));
            var submission = new Submission
            {
                Code = ProblemSolution,
                Language = Language,
                DateSubmit = DateTime.Now,
                Status = "Running",
                Problem = problem,
                Account = account
            };
            _context.Submission.Add(submission);
            _context.SaveChanges();
            return RedirectToAction("Detail", "Submission", submission);
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