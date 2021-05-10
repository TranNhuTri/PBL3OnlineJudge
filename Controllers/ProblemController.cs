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
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;


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
        public async Task<IActionResult> Edit(string id, [Bind("ID, Title, Content, Difficulty, Public, TimeLimit, MemoryLimit")] Problem problem)
        {
            if(id != problem.ID)
            {
                return NotFound();
            }
            var probl = _context.Problem.FirstOrDefault(m => m.ID == id);
            probl.Title = problem.Title;
            probl.Content = problem.Content;
            probl.Difficulty = problem.Difficulty;
            probl.Public = problem.Public;
            probl.TimeLimit = problem.TimeLimit;
            probl.MemoryLimit = problem.MemoryLimit;

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
            if(String.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
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
        public async Task<IActionResult> Submit(string id, string ProblemSolution, string Language)
        {
            var problem = _context.Problem.Include(p => p.TestCases).FirstOrDefault(p => p.ID == id);
            var account = _context.User.FirstOrDefault(a => a.UserName == HttpContext.Session.GetString("UserName"));

            var submission = new Submission
            {
                Code = ProblemSolution,
                Language = Language,
                TimeCreate = DateTime.Now,
                Status = "Running",
                Problem = problem,
                User = account
            };

            _context.Submission.Add(submission);
            _context.SaveChanges();
            
            var code = new code()
            {
                script = submission.Code,
                language = submission.Language,
                versionIndex = 0,
            };

            HttpClient client = new HttpClient();   
            client.BaseAddress = new Uri("https://api.jdoodle.com/");
            bool ACCheck = true;
            foreach(TestCase t in problem.TestCases)
            {
                code.stdin = t.Input;
                var response = client.PostAsJsonAsync("v1/execute", code).Result;
                var output = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {  
                    var submitResponse = JsonConvert.DeserializeObject<SubmitResponse>(output);
                    Console.WriteLine(submitResponse.output);
                    SubmissionResult sr = new SubmissionResult()
                    {
                        Submission = submission,
                        TestCase = t,
                        Result = submitResponse.output
                    };

                    if(submitResponse.output != t.Output)
                    {
                        ACCheck = false;
                        sr.Status = "Wrong Answer";
                    }
                    else
                    {
                        sr.Status = "OK";
                    }
                    _context.SubmissionResult.Add(sr);
                }
            }
            if(ACCheck== true)
                submission.Status = "Accepted";
            else
                submission.Status = "Wrong Answer";
            
            _context.Submission.Update(submission);
            _context.SaveChanges();
            return RedirectToAction("Submission", "ListSubmissions", submission.ID);
        } 
        public IActionResult Submissions(string problemID, string accountName)
        {
            if(problemID == null || accountName == null)
            {
                return NotFound();
            }
            var listSubmissions = (from Submission in _context.Submission.Include(s => s.User).Include(s => s.Problem) where (Submission.Problem.ID == problemID && Submission.User.UserName == accountName) select Submission).ToList();
            listSubmissions.Reverse();
            return View(listSubmissions);
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