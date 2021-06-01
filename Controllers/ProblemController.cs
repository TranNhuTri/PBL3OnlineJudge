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


namespace PBL3.Controllers
{
    public class ProblemController : Controller
    {
        private readonly PBL3Context _context;
        public ProblemController(PBL3Context context)
        {
            _context = context;
        }
        public IActionResult Edit(int id)
        {
            var problem = _context.Problems.Include(p => p.problemAuthors)
                                            .Include(problem => problem.problemClassifications)
                                            .AsSplitQuery().OrderBy(p => p.title)
                                            .FirstOrDefault(p => p.ID == id);
            
            ViewData["ListAuthors"] = _context.Accounts.Where(p => p.typeAccount == 2 || p.typeAccount == 1).OrderBy(p => p.accountName).ToList();

            ViewData["ListCategories"] = _context.Categories.OrderBy(p => p.name).ToList();

            ViewData["ListChosenAuthorIds"] = problem.problemAuthors.Where(p => p.isDeleted == false).Select(p => p.authorID).ToList();

            ViewData["ListChosenCategoryIds"] = problem.problemClassifications.Where(p => p.isDeleted == false).Select(p => p.categoryID).ToList();

            return View(problem);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("code, title, content, difficulty, isPublic, timeLimit, memoryLimit")] Problem reqProblem, List<int> reqListAuthorIds, List<int> reqListCategoryIds, string next)
        {
            if(_context.Problems.FirstOrDefault(p => p.ID == id) == null)
            {
                return NotFound();
            }
            ViewData["ListAuthors"] = _context.Accounts.Where(p => p.typeAccount == 2 || p.typeAccount == 1).OrderBy(p => p.accountName).ToList();

            ViewData["ListCategories"] = _context.Categories.OrderBy(p => p.name).ToList();

            ViewData["ListChosenAuthorIds"] = reqListAuthorIds;

            ViewData["ListChosenCategoryIds"] = reqListCategoryIds;

            if(ModelState.IsValid)
            {
                if(reqListAuthorIds.Count == 0)
                {
                    ModelState.AddModelError("", "Bạn cần chọn tác giả");
                    return View(reqProblem);
                }
                if(reqListCategoryIds.Count == 0)
                {
                    ModelState.AddModelError("", "Bạn cần chọn dạng bài");
                    return View(reqProblem);
                }
                var problem =  _context.Problems.Include(p => p.problemAuthors)
                                                .Include(p => p.problemClassifications)
                                                .AsSplitQuery().OrderBy(p => p.title)
                                                .FirstOrDefault(p => p.ID == id);
                
                problem.code = reqProblem.code;
                problem.title = reqProblem.title;
                problem.content = reqProblem.content;
                problem.difficulty = reqProblem.difficulty;
                problem.isPublic = reqProblem.isPublic;
                problem.timeLimit = reqProblem.timeLimit;
                problem.memoryLimit = reqProblem.memoryLimit;

                foreach(var item in problem.problemAuthors)// old problem.problemAuthors     new reqListAuthorIds
                {
                    //delete
                    if(reqListAuthorIds.Any(p => p == item.authorID) == false)
                    {
                        item.isDeleted = true;
                        _context.Update(item);
                    }
                }
                foreach(var item in reqListAuthorIds)
                {
                    //add
                    if(problem.problemAuthors.Any(p => p.authorID == item) == false)
                    {
                        _context.Add(new ProblemAuthor()
                        {
                            authorID = item,
                            problem = problem
                        });
                    }
                    else
                    {
                        var tmpt = problem.problemAuthors.FirstOrDefault(p => p.authorID == item);
                        tmpt.isDeleted = false;
                        _context.Update(tmpt);
                    }
                }

                foreach(var item in problem.problemClassifications)
                {
                    //delete
                    if(reqListCategoryIds.Any(p => p == item.categoryID) == false)
                    {
                        item.isDeleted= true;
                        _context.Update(item);
                    }
                }
                foreach(var item in reqListCategoryIds)
                {
                    //add
                    if(problem.problemClassifications.Any(p => p.categoryID == item) == false)
                    {
                        _context.Add(new ProblemClassification()
                        {
                            categoryID = item,
                            problem = problem
                        });
                    }
                    else
                    {
                        var tmpt = problem.problemClassifications.FirstOrDefault(p => p.categoryID == item);
                        tmpt.isDeleted = false;
                        _context.Update(tmpt);
                    }
                }

                _context.Update(problem);
                await _context.SaveChangesAsync();
                if(next == "edit")
                {
                    return RedirectToAction("Edit", id);
                }
                return RedirectToAction("ListProblems", "Admin");
            }
            return View(reqProblem);
        }
        public IActionResult Submit(int id)
        {
            if(String.IsNullOrEmpty(HttpContext.Session.GetString("AccountName")))
            {
                return RedirectToAction("Login", "Account");
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
        public IActionResult Submissions(int problemID, string accountName)
        {
            if(accountName == null)
            {
                return NotFound();
            }

            var listSubmissions = (from submission in _context.Submissions.Include(p => p.account).Include(p => p.problem) where (submission.problem.ID == problemID && submission.account.accountName == accountName) select submission).ToList();
            
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