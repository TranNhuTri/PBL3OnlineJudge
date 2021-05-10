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
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID, Title, Content, Difficulty, TimeLimit, MemoryLimit, Public")] Problem problem)
        {
            if (ModelState.IsValid)
            {
                if(_context.Problem.FirstOrDefault(p => p.ID == problem.ID) != null)
                {
                    return NotFound();
                }
                problem.TimeCreate = DateTime.Now;
                problem.User = _context.User.FirstOrDefault(a => a.UserName == HttpContext.Session.GetString("UserName"));
                _context.Add(problem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(problem);
        }
        public IActionResult Problem(string id)
        {
            var problem = _context.Problem.FirstOrDefault(m => m.ID == id);
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
