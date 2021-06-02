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
        public IActionResult Login()
        {
            string returnUrl;
            if (Request.Headers["Referer"].ToString() != null)
            {
                returnUrl = System.Net.WebUtility.UrlEncode(Request.Headers["Referer"].ToString());
                ViewBag.ReturnURL = returnUrl;
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("accountName, passWord")]LoginAccount requestAccount, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                var account = _context.Accounts.FirstOrDefault(p => p.accountName == requestAccount.accountName && p.passWord == Utility.CreateMD5(requestAccount.passWord) && p.isActived == true);
                if(account != null)
                {
                    HttpContext.Session.SetString("AccountName", account.accountName);
                    HttpContext.Session.SetString("TypeAccount", Convert.ToString(account.typeAccount));
                    if(!string.IsNullOrEmpty(returnUrl))
                    {
                        returnUrl = System.Net.WebUtility.UrlDecode(returnUrl);
                        if(!returnUrl.Contains("Login") && !returnUrl.Contains("SignUp"))
                        {
                            return Redirect(returnUrl);
                        }
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không hợp lệ !");
                    return View();
                }
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
