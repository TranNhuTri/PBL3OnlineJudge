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
using PBL3.Features.SubmissionManagement;
using PBL3.Features.AccountManagement;
using PBL3.Features.ProblemManagement;
using PBL3.Repositories;

namespace PBL3.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionService _submissionService;
        private readonly IAccountService _accountService;
        private readonly IProblemService _problemService;
        private readonly IRepository<TestCase> _testCaseRepo;
        private readonly IRepository<SubmissionResult> _submissionResultRepo;
        public SubmissionsController(ISubmissionService submissionService, IAccountService accountService, IProblemService problemService, IRepository<TestCase> testCaseRepo, IRepository<SubmissionResult> submissionResultRepo, PBL3Context context)
        {
            _testCaseRepo = testCaseRepo;
            _submissionResultRepo = submissionResultRepo;
            _submissionService = submissionService;
            _accountService = accountService;
            _problemService = problemService;
        }
        public IActionResult Index(int? page)
        {
            var listSubmissions = _submissionService.GetAllSubmissions();
            foreach(var item in listSubmissions)
                item.account = _accountService.GetAccountByID(item.accountID);
            foreach(var item in listSubmissions)
                item.problem = _problemService.GetProblemByID(item.problemID);

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

            var submission = _submissionService.GetSubmissionByID((int)id);

            if(submission == null)
                return NotFound();

            return View(submission);
        }
        public IActionResult GetSubmission(int? id)
        {
            var submission  = _submissionService.GetSubmissionByID((int)id);
            submission.problem = _problemService.GetProblemByID(submission.problemID);
            submission.account = _accountService.GetAccountByID(submission.accountID);
            submission.submissionResults = _submissionResultRepo.GetAll().Where(p => p.submissionID == submission.ID && p.isDeleted == false).ToList();
            foreach(var item in submission.submissionResults)
                item.testCase = _testCaseRepo.GetAll().Where(p => p.ID == item.testCaseID).FirstOrDefault();

            return View(submission);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult EditSubmission(int id)
        {
            var submission  = _submissionService.GetSubmissionByID((int)id);

            if(submission == null)
            {
                return NotFound();
            }

            submission.problem = _problemService.GetProblemByID(submission.problemID);
            submission.account = _accountService.GetAccountByID(submission.accountID);
            submission.submissionResults = _submissionResultRepo.GetAll().Where(p => p.submissionID == submission.ID && p.isDeleted == false).ToList();

            return View(submission);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Resubmit(int id, string language)
        {
            var submission = _submissionService.GetSubmissionByID(id);

            var problem = _problemService.GetProblemByID(submission.problemID);
            problem.testCases = _testCaseRepo.GetAll().Where(p => p.problemID == submission.problemID).ToList();

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

            var submissionResults = _submissionResultRepo.GetAll().Where(p => p.submissionID == id).ToList();

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
                        if(res != txt)
                        {
                            ACCheck = false;
                            sr.status = "Wrong Answer";
                        }
                        else
                        {
                            sr.status = "Accepted";
                        }
                        _submissionResultRepo.Insert(sr);
                        _submissionResultRepo.Save();
                    }
                    else
                    {
                        sr = submissionResults[i - 1];
                        sr.result = Response.output;
                        sr.isDeleted = false;
                        var txt = System.IO.File.ReadAllText(tc.output);
                        txt = txt.Replace("\r", string.Empty);
                        var res = Response.output;
                        if(res != txt)
                        {
                            ACCheck = false;
                            sr.status = "Wrong Answer";
                        }
                        else
                        {
                            sr.status = "Accepted";
                        }
                        _submissionResultRepo.Update(sr);
                    }

                    excuteTime += Response.cpuTime;
                    memoryUsed += Response.memory;
                }
                i ++;
            }
            for(int j = i - 1; j < submissionResults.Count(); j++)
            {
                submissionResults[j].isDeleted = true;
                _submissionResultRepo.Update(submissionResults[j]);
            }

            if(ACCheck== true)
                submission.status = "Accepted";
            else
                submission.status = "Wrong Answer";

            submission.time = excuteTime;
            submission.memory = memoryUsed;

            _submissionService.UpdateSubmission(submission);

            return RedirectToAction(nameof(EditSubmission), new {id = id});
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteSubmission(int id)
        {
            var submission  = _submissionService.GetSubmissionByID((int)id);
            submission.problem = _problemService.GetProblemByID(submission.problemID);
            submission.account = _accountService.GetAccountByID(submission.accountID);
            submission.submissionResults = _submissionResultRepo.GetAll().Where(p => p.submissionID == submission.ID && p.isDeleted == false).ToList();
            
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
            var submission  = _submissionService.GetSubmissionByID((int)id);

            if(submission == null)
            {
                return NotFound();
            }

            _submissionService.ChangeIsDeleted((int) id);

            return RedirectToAction("Submissions", "Admin");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
