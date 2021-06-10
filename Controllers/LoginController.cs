using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PBL3.Models;
using PBL3.Data;
using PBL3.General;
using PBL3.DTO;

namespace PBL3.Controllers
{
    public class LoginController : Controller
    {
        private readonly PBL3Context _context;
        public LoginController(PBL3Context context)
        {
            _context = context;
        }
        public IActionResult UserLogin()
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
        public IActionResult UserLogin([Bind("accountName, passWord")]LoginAccount requestAccount, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                var account = _context.Accounts.Where(p => p.accountName == requestAccount.accountName && p.passWord == Utility.CreateMD5(requestAccount.passWord) && p.isActived == true && p.isDeleted == false).Include(p => p.role).FirstOrDefault();
                if(account != null)
                {
                    var userClaims = new List<Claim>()
                    {
                        new Claim("UserID", account.ID.ToString()),
                        new Claim("UserName", account.accountName),
                        new Claim(ClaimTypes.Name, account.lastName + " " + account.firstName),
                        new Claim(ClaimTypes.Email, account.email),
                        new Claim(ClaimTypes.Role, account.role.name),
                        new Claim("Role", account.role.name),
                    };

                    var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                    HttpContext.SignInAsync(userPrincipal);

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
        public IActionResult AccessDenied()
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
