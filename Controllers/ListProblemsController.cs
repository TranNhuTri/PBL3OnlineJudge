using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PBL3.Models;
using PBL3.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PBL3.Controllers
{
    public class ListProblemsController : Controller
    {
        private readonly PBL3Context _context;
        public ListProblemsController(PBL3Context context)
        {
            _context = context;
        }
        public IActionResult Index(string ProblemName, bool HideSolvedProblem, string ProblemCategory, int? MinDifficult, int? MaxDifficult)
        {
            var problems = _context.Problem.ToList();
            var seachForm = new SearchForm();
            ViewData["ListCategories"] = _context.Category.ToList();
            
            if(!String.IsNullOrEmpty(ProblemName))
            {
                problems = problems.Where(p => p.Title.ToLower().Contains(ProblemName.ToLower())).Select(p => p).ToList();
                seachForm.ProblemName = ProblemName;
            }
            if(!String.IsNullOrEmpty(ProblemCategory))
            {
                //
            }
            if(MinDifficult != null || MaxDifficult != null)
            {
                if(MinDifficult != null)
                {
                    problems = problems.Where(p => p.Difficulty >= MinDifficult).Select(p => p).ToList();
                    seachForm.MinDiff = MinDifficult;
                }
                if(MaxDifficult != null)
                {
                    problems = problems.Where(p => p.Difficulty <= MaxDifficult).Select(p => p).ToList();
                    seachForm.MaxDiff = MaxDifficult;
                }
            }
            ViewData["SearchForm"] = seachForm;
            return View(problems.ToList());
        }
        public IActionResult Create()
        {
            var listAuthors = _context.User.Where(user => user.TypeAccount == 2 || user.TypeAccount == 1).OrderBy(user => user.UserName).Select(user => user).ToList();
            ViewData["ListAuthors"] = listAuthors;
            ViewData["ListCategories"] = _context.Category.OrderBy(cate => cate.Name).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID, Title, Content, Difficulty, TimeLimit, MemoryLimit, Public")] Problem problem, int[] Authors, int[] Categories)
        {
            var listAuthors = _context.User.Where(user => user.TypeAccount == 2 || user.TypeAccount == 1).OrderBy(user => user.UserName).Select(user => user).ToList();
            ViewData["ListAuthors"] = listAuthors;
            ViewData["ListCategories"] = _context.Category.OrderBy(cate => cate.Name).ToList();

            var listChosenAuthors = new List<int>();
            foreach(int id in Authors)
            {
                listChosenAuthors.Add(_context.User.Select(user => user.ID).FirstOrDefault(ID => ID == id));
            }

            var listChosenCategories = new List<int>();
            foreach(int id in Categories)
            {
                listChosenCategories.Add(_context.Category.Select(cate => cate.ID).FirstOrDefault(ID => ID == id));
            }

            ViewData["ListChosenAuthors"] = listChosenAuthors;
            ViewData["ListChosenCategories"] = listChosenCategories;

            if (ModelState.IsValid)
            {
                if(Authors.Length == 0)
                {
                    ModelState.AddModelError("", "Bạn cần chọn tác giả");
                    return View();
                }
                if(Categories.Length == 0)
                {
                    ModelState.AddModelError("", "Bạn cần chọn dạng bài");
                    return View();
                }
                if(_context.Problem.FirstOrDefault(p => p.ID == problem.ID) != null)
                {
                    ModelState.AddModelError("", "Mã bài đã tồn tại");
                    return View();
                }
                problem.TimeCreate = DateTime.Now;

                foreach(int id in Authors)
                {
                    var problemAuthor = new ProblemAuthor()
                    {
                        Problem = problem,
                        AuthorID = id
                    };
                    _context.Add(problemAuthor);
                }
                foreach(int id in Categories)
                {
                    var problemCategory = new ProblemCategory()
                    {
                        Problem = problem,
                        CategoryID = id
                    };
                    _context.Add(problemCategory);
                }
                _context.Add(problem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Problem(string id)
        {
            var problem = _context.Problem.Include(p => p.ProblemAuthors).ThenInclude(p => p.Author).FirstOrDefault(p => p.ID == id);
            return View(problem);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var problem = _context.Problem.FirstOrDefault(p => p.ID == id);
            if(problem == null)
                return NotFound();
            _context.Remove(problem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
