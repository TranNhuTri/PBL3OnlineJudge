using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PBL3.Models;
using PBL3.DTO;
using PBL3.Data;
using PBL3.General;
using System.Threading.Tasks;

namespace PBL3.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly PBL3Context _context;
        public ArticlesController(PBL3Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Articles()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
