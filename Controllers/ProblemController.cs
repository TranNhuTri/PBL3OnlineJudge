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
            var problem = _context.Problem.Include(problem => problem.ProblemAuthors).Include(problem => problem.ProblemCategories).AsSplitQuery().OrderBy(m => m.Title).FirstOrDefault(problem => problem.ID == id);
            var listAuthors = _context.User.Where(user => user.TypeAccount == 2 || user.TypeAccount == 1).OrderBy(user => user.UserName).Select(user => user).ToList();
            ViewData["ListAuthors"] = listAuthors;
            ViewData["ListCategories"] = _context.Category.OrderBy(cate => cate.Name).ToList();

            var listChosenAuthors = new List<int>();
            foreach(int Id in problem.ProblemAuthors.Select(p => p.AuthorID).ToList())
            {
                listChosenAuthors.Add(_context.User.Select(user => user.ID).FirstOrDefault(ID => ID == Id));
            }

            var listChosenCategories = new List<int>();
            foreach(int Id in problem.ProblemCategories.Select(p => p.CategoryID))
            {
                listChosenCategories.Add(_context.Category.Select(cate => cate.ID).FirstOrDefault(ID => ID == Id));
            }

            ViewData["ListChosenAuthors"] = listChosenAuthors;
            ViewData["ListChosenCategories"] = listChosenCategories;
            return View(problem);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID, Title, Content, Difficulty, Public, TimeLimit, MemoryLimit")] Problem problem, List<int> Authors, List<int> Categories)
        {
            if(id != problem.ID)
            {
                return NotFound();
            }
            var listAuthors = _context.User.Where(user => user.TypeAccount == 2 || user.TypeAccount == 1).OrderBy(user => user.UserName).Select(user => user).ToList();
            ViewData["ListAuthors"] = listAuthors;
            ViewData["ListCategories"] = _context.Category.OrderBy(cate => cate.Name).ToList();

            var listChosenAuthors = new List<int>();
            foreach(int Id in Authors)
            {
                listChosenAuthors.Add(_context.User.Select(user => user.ID).FirstOrDefault(ID => ID == Id));
            }

            var listChosenCategories = new List<int>();
            foreach(int Id in Categories)
            {
                listChosenCategories.Add(_context.Category.Select(cate => cate.ID).FirstOrDefault(ID => ID == Id));
            }

            ViewData["ListChosenAuthors"] = listChosenAuthors;
            ViewData["ListChosenCategories"] = listChosenCategories;

            if(ModelState.IsValid)
            {
                if(Authors.Count == 0)
                {
                    ModelState.AddModelError("", "Bạn cần chọn tác giả");
                    return View(problem);
                }
                if(Categories.Count == 0)
                {
                    ModelState.AddModelError("", "Bạn cần chọn dạng bài");
                    return View(problem);
                }
                var probl = _context.Problem.Include(p => p.ProblemAuthors).Include(p => p.ProblemCategories).AsSplitQuery().OrderBy(p => p.Title).FirstOrDefault(m => m.ID == id);
                probl.Title = problem.Title;
                probl.Content = problem.Content;
                probl.Difficulty = problem.Difficulty;
                probl.Public = problem.Public;
                probl.TimeLimit = problem.TimeLimit;
                probl.MemoryLimit = problem.MemoryLimit;
                
                List<int> updateAuthorID = new List<int>();
                List<int> bothAuthorID = new List<int>();

                foreach(ProblemAuthor i in probl.ProblemAuthors)
                {
                    if(Authors.IndexOf(i.AuthorID) != -1)
                    {
                        bothAuthorID.Add(i.AuthorID);
                    }
                    else
                    {
                        updateAuthorID.Add(i.AuthorID);
                    }
                }
                foreach(int i in bothAuthorID)
                {
                    Authors.Remove(i);
                }
                if(updateAuthorID.Count > Authors.Count)
                {
                    for(int i = 0; i < Authors.Count; i ++)
                    {
                        var problemAuthor = _context.ProblemAuthor.FirstOrDefault(p => p.ProblemID == id && p.AuthorID == updateAuthorID[i]);
                        problemAuthor.AuthorID = Authors[i];
                        _context.Update(problemAuthor);
                    }
                    for(int i = Authors.Count; i < updateAuthorID.Count; i++)
                    {
                        var problemAuthor = _context.ProblemAuthor.FirstOrDefault(p => p.ProblemID == id && p.AuthorID == updateAuthorID[i]);
                        _context.Remove(problemAuthor);
                    }
                }
                else
                {
                    for(int i = 0; i < updateAuthorID.Count; i ++)
                    {
                        var problemAuthor = _context.ProblemAuthor.FirstOrDefault(p => p.ProblemID == id && p.AuthorID == updateAuthorID[i]);
                        problemAuthor.AuthorID = Authors[i];
                        _context.Update(problemAuthor);
                    }
                    for(int i = updateAuthorID.Count; i < Authors.Count; i++)
                    {
                        var problemAuthor = new ProblemAuthor()
                        {
                            ProblemID = id,
                            AuthorID = Authors[i]
                        };
                        _context.Add(problemAuthor);
                    }
                }

                List<int> updateCategoryID = new List<int>();
                List<int> bothCategoryID = new List<int>();

                foreach(ProblemCategory i in probl.ProblemCategories)
                {
                    if(Categories.IndexOf(i.CategoryID) != -1)
                    {
                        bothCategoryID.Add(i.CategoryID);
                    }
                    else
                    {
                        updateCategoryID.Add(i.CategoryID);
                    }
                }
                foreach(int i in bothCategoryID)
                {
                    Categories.Remove(i);
                }
                if(updateCategoryID.Count > Categories.Count)
                {
                    for(int i = 0; i < Categories.Count; i ++)
                    {
                        var problemCategory = _context.ProblemCategory.FirstOrDefault(p => p.ProblemID == id && p.CategoryID == updateCategoryID[i]);
                        problemCategory.CategoryID = Categories[i];
                        _context.Update(problemCategory);
                    }
                    for(int i = Categories.Count; i < updateCategoryID.Count; i++)
                    {
                        Console.WriteLine(updateCategoryID[i]);
                        var problemCategory = _context.ProblemCategory.FirstOrDefault(p => p.ProblemID == id && p.CategoryID == updateCategoryID[i]);
                        _context.Remove(problemCategory);
                    }
                }
                else
                {
                    for(int i = 0; i < updateCategoryID.Count; i ++)
                    {
                        var problemCategory = _context.ProblemCategory.FirstOrDefault(p => p.ProblemID == id && p.CategoryID == updateCategoryID[i]);
                        problemCategory.CategoryID = Categories[i];
                        _context.Update(problemCategory);
                    }
                    for(int i = updateCategoryID.Count; i < Categories.Count; i++)
                    {
                        var ProblemCategory = new ProblemCategory()
                        {
                            ProblemID = id,
                            CategoryID = Categories[i]
                        };
                        _context.Add(ProblemCategory);
                    }
                }

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