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
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;

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
        public async Task<IActionResult> Resubmit(int id, string language)
        {
            var submission = _context.Submissions.FirstOrDefault(p => p.ID == id);

            var problem = _context.Problems.Where(p => p.ID == submission.problemID).Include(p => p.testCases).FirstOrDefault();

            var Code = new Code()
            {
                script = submission.code,
                language = language,
                versionIndex = 0,
            };

            HttpClient client = new HttpClient();   
            client.BaseAddress = new Uri("https://api.jdoodle.com/");

            bool ACCheck = true;
            float excuteTime = 0;
            float memoryUsed = 0;

            int i = 1;

            var submissionResults = _context.SubmissionResults.Where(p => p.submissionID == id).ToList();

            foreach(TestCase tc in problem.testCases.Where(p => p.isDeleted == false))
            {
                Code.stdin = System.IO.File.ReadAllText(tc.input);

                var response = client.PostAsJsonAsync("v1/execute", Code).Result;

                var output = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {  
                    var Response = JsonConvert.DeserializeObject<Response>(output);

                    Console.WriteLine(Response.output);

                    var sr = new SubmissionResult();
                    
                    if(i > submissionResults.Count)
                    {
                        sr =  new SubmissionResult()
                        {
                            submission = submission,
                            testCase = tc,
                            result = Response.output,
                            excuteTime = Response.cpuTime,
                            memory = Response.memory
                        };
                        var txt = System.IO.File.ReadAllText(tc.output);
                        var res = Response.output;
                        txt = txt.Replace("\r", string.Empty);
                        /*Console.WriteLine("(");
                        Console.WriteLine(Response.output);
                        Console.WriteLine("------");
                        Console.WriteLine(System.IO.File.ReadAllText(tc.output));
                        Console.WriteLine(")");*/
                        if(res != txt)
                        {
                            ACCheck = false;
                            sr.status = "Wrong Answer";
                        }
                        else
                        {
                            sr.status = "Accepted";
                        }
                        _context.Add(sr);
                    }
                    else
                    {
                        sr = submissionResults[i - 1];
                        sr.result = Response.output;
                        sr.isDeleted = false;
                        var txt = System.IO.File.ReadAllText(tc.output);
                        txt = txt.Replace("\r", string.Empty);
                        var res = Response.output;
                        /*Console.WriteLine(Response.output);
                        Console.WriteLine("------");
                        Console.WriteLine(System.IO.File.ReadAllText(tc.output));*/
                        if(res != txt)
                        {
                            ACCheck = false;
                            sr.status = "Wrong Answer";
                        }
                        else
                        {
                            sr.status = "Accepted";
                        }
                        _context.SubmissionResults.Update(sr);
                    }

                    excuteTime += Response.cpuTime;
                    memoryUsed += Response.memory;
                }
                i ++;
            }
            for(int j = i - 1; j < submissionResults.Count(); j++)
            {
                submissionResults[j].isDeleted = true;
                _context.Update(submissionResults[j]);
            }

            if(ACCheck== true)
                submission.status = "Accepted";
            else
                submission.status = "Wrong Answer";

            submission.time = excuteTime;
            submission.memory = memoryUsed;

            _context.Update(submission);

            _context.SaveChanges();

            return RedirectToAction(nameof(EditSubmission), new {id = id});
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteSubmission(int id)
        {
            var submission = _context.Submissions.Where(p => p.ID == id)
                                                .Include(p => p.problem)
                                                .Include(p => p.submissionResults)
                                                .Include(p => p.account)
                                                .FirstOrDefault();
            if(submission == null)
            {
                return NotFound();
            }
            return View(submission);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSubmission(int? id)
        {
            var submission = _context.Submissions.Include(p => p.problem).Include(p => p.account).FirstOrDefault(p => p.ID == id);

            if(submission == null)
            {
                return NotFound();
            }

            submission.isDeleted = true;

            _context.Update(submission);

            _context.SaveChanges();

            return RedirectToAction("Submissions", "Admin");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
