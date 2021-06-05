using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PBL3.Models;
using PBL3.Data;
using PBL3.General;
using PBL3.DTO;

namespace PBL3.Controllers
{
    public class LogoutController : Controller
    {
        private readonly PBL3Context _context;
        public LogoutController(PBL3Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HttpContext.Session.SetString("AccountName", string.Empty);
            HttpContext.Session.SetString("TypeAccount", String.Empty);
            return RedirectToAction("Index", "Home");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
