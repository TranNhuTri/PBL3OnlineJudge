using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index(string ProblemName = "", bool HideSolvedProblem = false, string ProblemCategory = "", int MinDifficult = 0, int MaxDifficult = (int)1e9)
        {
            var problems = from problem in _context.Problems select problem;
            problems = problems.Where(p => p.Difficulty >= MinDifficult && p.Difficulty <= MaxDifficult);
            if(!String.IsNullOrEmpty(ProblemName))
            {
                problems = problems.Where(p => p.Title.ToLower().Contains(ProblemName.ToLower()));
            }
            if(HideSolvedProblem == true)
            {
                problems = problems.Where(p => p.Status == false);
            }
            return View(problems.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID, Title, Content, Difficulty")] Problem problem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(problem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(problem);
        }
        public IActionResult Edit(string id)
        {
            var model = _context.Problems.FirstOrDefault(m => m.ID == id);
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
            var probl = _context.Problems.FirstOrDefault(m => m.ID == id);
            probl.Title = problem.Title;
            probl.Content = problem.Content;
            probl.Difficulty = problem.Difficulty;

            if (ModelState.IsValid && probl != null)
            {
                _context.Update(probl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(problem);
        }
        public IActionResult Problem(string id)
        {
            var problem = _context.Problems.FirstOrDefault(m => m.ID == id);
            return View(problem);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
