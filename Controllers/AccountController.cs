using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PBL3.Models;
using PBL3.Data;
using PBL3.General;
using PBL3.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace PBL3.Controllers
{
    public class AccountController : Controller
    {
        private readonly PBL3Context _context;
        public AccountController(PBL3Context context)
        {
            _context = context;
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
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                    return View(reqAccount);
                }
                if(ConfirmPassword != reqAccount.passWord)
                {
                    ModelState.AddModelError("", "Mật khẩu không khớp nhau");
                    return View(reqAccount);
                }
                if(!String.IsNullOrEmpty(reqAccount.email))
                {
                    reqAccount.timeCreate = DateTime.Now;
                    reqAccount.token = Utility.CreateMD5(reqAccount.accountName);
                    reqAccount.passWord = Utility.CreateMD5(reqAccount.passWord);
                    reqAccount.roleID = 3;

                    var message = "Chào mừng bạn đến với CodeTop1. Nhấn vào đường link sau để xác thực email ! https://localhost:5001/Account/VerifyMail?token=" + reqAccount.token + "&&email=" + reqAccount.email;
                    
                    _context.Accounts.Add(reqAccount);
                    _context.SaveChangesAsync();

                    Utility.sendMail(reqAccount.email, message);

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
        public IActionResult AccountProfile(string accountName)
        {
            var account = _context.Accounts.Where(p => p.accountName == accountName).Include(p => p.submissions).ThenInclude(p => p.problem).FirstOrDefault();
            if(account == null)
                return NotFound();
            return View(account);
        }
        [Authorize]
        public IActionResult EditAccountProfile(string name)
        {
            if(name != HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserName").Value)
            {
                return NotFound();
            }
            var account = _context.Accounts.FirstOrDefault(p => p.accountName == name);
            if(account == null)
                return NotFound();
            return View(account);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAccountProfile(string name, [Bind("accountName, firstName, lastName, email")]EditAccount editAccount)
        {
            if(name != HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserName").Value)
            {
                return NotFound();
            }
            var account = _context.Accounts.FirstOrDefault(p => p.accountName == name);

            if(account == null)
                return NotFound();
        
            account.firstName = editAccount.firstName;
            account.lastName = editAccount.lastName;
            account.email = editAccount.email;

            _context.Update(account);
            _context.SaveChanges();

            return View(account);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
