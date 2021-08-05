using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PBL3.Models;
using PBL3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using PBL3.General;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace PBL3.Controllers
{
    public class ProblemController : Controller
    {
        private readonly PBL3Context _context;
        private IWebHostEnvironment _hostEnvironment;
        public ProblemController(PBL3Context context, IWebHostEnvironment env)
        {
            _context = context;
            _hostEnvironment = env;
        }
        public IActionResult UploadTestcase(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UploadTestcase(int id, List<IFormFile> files)
        { 
            if (ModelState.IsValid)
            {
                if(files.Count % 2 != 0 || Utility.CheckTestcase(files) == false)
                {
                    ModelState.AddModelError("", "Testcases không đúng định dạng");
                    return View();
                }

                var problem = _context.Problems.Where(p => p.ID == id).Include(p => p.testCases).FirstOrDefault();

                var testCases = problem.testCases;

                List<string> inputFiles = new List<string>(), outputFiles = new List<string>();

                foreach (var file in files)
                {
                    var InputFileName = Utility.CreateMD5(problem.code + problem.ID.ToString() + Path.GetFileName(file.FileName));

                    var ServerSavePath = Path.Combine(_hostEnvironment.WebRootPath + "/UploadedFiles/TestCases/" + InputFileName);

                    var stream = new FileStream(ServerSavePath, FileMode.Create);

                    await file.CopyToAsync(stream);

                    stream.Close();

                    if(Path.GetFileName(file.FileName).Contains("input"))
                    {
                        inputFiles.Add(ServerSavePath);
                    }
                    else
                    {
                        outputFiles.Add(ServerSavePath);
                    }
                }
                for(int i = 1; i <= files.Count/2; i++)
                {

                    if(i > testCases.Count)
                    {
                        _context.Add(new TestCase()
                        {
                            input = inputFiles[i - 1],
                            output = outputFiles[i - 1],
                            problemID = problem.ID,
                        });
                    }
                    else
                    {
                        problem.testCases[i - 1].input = inputFiles[i - 1];
                        problem.testCases[i - 1].output = outputFiles[i - 1];
                        problem.testCases[i - 1].isDeleted = false;
                        _context.Update(problem.testCases[i - 1]);
                    }
                }
                for(int i = files.Count/2; i < problem.testCases.Count; i++)
                {
                    problem.testCases[i].isDeleted = true;
                    _context.Update(problem.testCases[i]);
                }
                _context.SaveChanges();
                return RedirectToAction("EditProblem", "Problems", new {id = id});
            }
            return NotFound();
        }  
        [Authorize]
        public IActionResult Submit(int id)
        {
            var problem = _context.Problems.FirstOrDefault(p => p.ID == id);

            if(problem == null)
            {
                return NotFound();
            }

            return View(problem);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(int id, string problemSolution, string language)
        {
            var problem = _context.Problems.Include(p => p.testCases).FirstOrDefault(p => p.ID == id);
            
            var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);

            var mySubmission = new Submission
            {
                code = problemSolution,
                language = language,
                timeCreate = DateTime.Now,
                status = "Running",
                problem = problem,
                account = _context.Accounts.FirstOrDefault(p => p.ID == accountID)
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

            foreach(TestCase tc in problem.testCases.Where(p => p.isDeleted == false))
            {
                code.stdin = System.IO.File.ReadAllText(tc.input);

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
                    if(Response.output != System.IO.File.ReadAllText(tc.output))
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
                {"accountName", HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserName").Value},
            });
        }
        public IActionResult Submissions(int? page, int problemID, string accountName)
        {
            List<Submission> listSubmissions = new List<Submission>();

            var paramater = new Dictionary<string, string>();

            if(accountName == null)
                listSubmissions = _context.Submissions.Where(p => p.problemID == problemID).Include(p => p.account).Include(p => p.problem).OrderByDescending(p => p.timeCreate).ToList();
            else
            {
                listSubmissions = (from submission in _context.Submissions.Include(p => p.account).Include(p => p.problem) where (submission.problem.ID == problemID && submission.account.accountName == accountName) select submission).OrderByDescending(p => p.timeCreate).ToList();
                paramater.Add("accountName", accountName);
            }

            paramater.Add("problemID", problemID.ToString());

            ViewBag.paginationParams = paramater;

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
    public string clientSecret{get; set;} = "3045ce1542ce96ae95a70162e2bdb8595fe05d1ba50494255d05a15477836be8";
}
class Response
{
    public string output{get; set;}
    public int statusCode{get; set;}
    public int memory{get; set;}
    public float cpuTime{get; set;}
}