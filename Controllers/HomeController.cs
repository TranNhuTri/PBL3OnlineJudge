using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PBL3.Models;
using PBL3.Data;

namespace PBL3.Controllers
{
    public class HomeController : Controller
    {
        private readonly PBL3Context _context;
        public HomeController(PBL3Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var accountName = HttpContext.Session.GetString("AccountName");
            if(!String.IsNullOrEmpty(accountName))
            {
                ViewData["Submissions"] = _context.Submissions.Where(s => s.account.accountName == accountName).ToList().Count;
                ViewData["ACSubmissions"] = _context.Submissions.Where(s => s.account.accountName == accountName && s.status == "Accepted").ToList().Count;
                ViewData["WASubmissions"] = _context.Submissions.Where(s => s.account.accountName == accountName && s.status == "Wrong Answer").ToList().Count;
                ViewData["TLESubmissions"] = _context.Submissions.Where(s => s.account.accountName == accountName && s.status == "TLE").ToList().Count;
            }
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
