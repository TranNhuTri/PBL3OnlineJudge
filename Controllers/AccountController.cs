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

namespace PBL3.Controllers
{
    public class AccountController : Controller
    {
        static string key { get; set; } = "trannhutri0703phandinhkhoi2312nhatlong2509dosanh0804";
        private readonly PBL3Context _context;
        public AccountController(PBL3Context context)
        {
            _context = context;
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

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("AccountName", string.Empty);
            HttpContext.Session.SetString("TypeAccount", String.Empty);
            return RedirectToAction("Index", "Home");
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
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp([Bind("accountName", "passWord", "email", "lastName", "firstName")]Account reqAccount, string ConfirmPassword, string LastName, string FirstName)
        {
            if(ModelState.IsValid)
            {
                var account = _context.Accounts.FirstOrDefault(p => p.accountName == reqAccount.accountName);
                if(account != null)
                {
                    return NotFound();
                }
                if(!String.IsNullOrEmpty(reqAccount.email))
                {
                    reqAccount.timeCreate = DateTime.Now;
                    reqAccount.token = Utility.CreateMD5(reqAccount.accountName);
                    reqAccount.passWord = Utility.CreateMD5(reqAccount.passWord);
                    reqAccount.typeAccount = 3;

                    var message = "Chào mừng bạn đến với CodeTop1. Nhấn vào đường link sau để xác thực email ! https://localhost:5001/Account/VerifyMail?token=" + reqAccount.token + "&&email=" + reqAccount.email;

                    Utility.sendMail(reqAccount.email, message);

                    _context.Accounts.Add(reqAccount);
                    _context.SaveChangesAsync();

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(reqAccount);
        }
        public IActionResult VerifyMail(string token, string email)
        {
            var account = _context.Accounts.FirstOrDefault(p => p.token == token && p.email == email && p.isActived == false);

            if(account != null)
            {
                if(DateTime.Compare(account.timeCreate.AddHours(4), DateTime.Now) >= 0)
                {
                    account.isActived = true;
                    _context.Update(account);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    _context.Accounts.Remove(account);
                    _context.SaveChanges();
                }
            }
            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
