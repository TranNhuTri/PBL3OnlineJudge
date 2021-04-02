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
        public IActionResult Index()
        {
            var problems = _context.Problems.OrderByDescending(m => m.ID).Take(10).ToList();
            return View(problems);
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
