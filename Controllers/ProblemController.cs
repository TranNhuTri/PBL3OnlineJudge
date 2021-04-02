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
    public class ProblemController : Controller
    {
        private readonly PBL3Context _context;
        public ProblemController(PBL3Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Submit(string id)
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
