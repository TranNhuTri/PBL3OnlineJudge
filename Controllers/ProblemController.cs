using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PBL3.Models;
using PBL3.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using PBL3.General;


namespace PBL3.Controllers
{
    public class ProblemController : Controller
    {
        private readonly PBL3Context _context;
        public ProblemController(PBL3Context context)
        {
            _context = context;
        }
        public IActionResult Submit(int id)
        {
            if(String.IsNullOrEmpty(HttpContext.Session.GetString("AccountName")))
            {
                return RedirectToAction("Login", "Home");
            }

            var problem = _context.Problems.FirstOrDefault(p => p.ID == id);

            if(problem == null)
            {
                return NotFound();
            }

            return View(problem);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(int id, string problemSolution, string language)
        {
            var problem = _context.Problems.Include(p => p.testCases).FirstOrDefault(p => p.ID == id);
            
            var account = _context.Accounts.FirstOrDefault(p => p.accountName == HttpContext.Session.GetString("AccountName"));

            var mySubmission = new Submission
            {
                code = problemSolution,
                language = language,
                timeCreate = DateTime.Now,
                status = "Running",
                problem = problem,
                account = account
            };
            
            var code = new Code()
            {
                script = mySubmission.code,
                language = mySubmission.language,
                versionIndex = 0,
            };

            HttpClient client = new HttpClient();   
            client.BaseAddress = new Uri("https://api.jdoodle.com/");

            bool ACCheck = true;
            float excuteTime = 0;
            float memoryUsed = 0;

            foreach(TestCase tc in problem.testCases)
            {
                code.stdin = tc.input;
                var response = client.PostAsJsonAsync("v1/execute", code).Result;
                var output = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {  
                    var Response = JsonConvert.DeserializeObject<Response>(output);
                    Console.WriteLine(Response.output);
                    SubmissionResult sr = new SubmissionResult()
                    {
                        submission = mySubmission,
                        testCase = tc,
                        result = Response.output,
                        excuteTime = Response.cpuTime,
                        memory = Response.memory
                    };
                    excuteTime += Response.cpuTime;
                    memoryUsed += Response.memory;
                    if(Response.output != tc.output)
                    {
                        ACCheck = false;
                        sr.status = "Wrong Answer";
                    }
                    else
                    {
                        sr.status = "Accepted";
                    }
                    _context.SubmissionResults.Add(sr);
                }
            }

            if(ACCheck== true)
                mySubmission.status = "Accepted";
            else
                mySubmission.status = "Wrong Answer";

            mySubmission.time = excuteTime;
            mySubmission.memory = memoryUsed;

            _context.Add(mySubmission);

            _context.SaveChanges();

            return RedirectToAction("Submissions", new Dictionary<string, string>
            {
                {"problemID", Convert.ToString(id)},
                {"accountName", account.accountName},
            });
        } 
        public IActionResult Submissions(int? page, int problemID, string accountName)
        {
            List<Submission> listSubmissions = new List<Submission>();
            if(accountName == null)
                listSubmissions = _context.Submissions.Where(p => p.problemID == problemID).Include(p => p.account).Include(p => p.problem).OrderByDescending(p => p.timeCreate).ToList();
            else
                listSubmissions = (from submission in _context.Submissions.Include(p => p.account).Include(p => p.problem) where (submission.problem.ID == problemID && submission.account.accountName == accountName) select submission).OrderByDescending(p => p.timeCreate).ToList();

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
class Code
{
    public string script{get; set;}
    public string language {get; set;}
    public int versionIndex{get; set;}
    public string stdin{get; set;}
    public string clientId{get; set;} = "672651acf3fa819a1e0c27a9fb272658";
    public string clientSecret{get; set;} = "eb951e6e38f239380084104d7629f1312d66345ec661a4da5bd62822ad3a842b";
}
class Response
{
    public string output{get; set;}
    public int statusCode{get; set;}
    public int memory{get; set;}
    public float cpuTime{get; set;}
}