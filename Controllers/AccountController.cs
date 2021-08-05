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
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;

namespace PBL3.Controllers
{
    public class AccountController : Controller
    {
        private readonly PBL3Context _context;
        private IWebHostEnvironment _hostEnvironment;
        public AccountController(PBL3Context context, IWebHostEnvironment env)
        {
            _context = context;
            _hostEnvironment = env;
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
                if(_context.Accounts.FirstOrDefault(p => p.email == reqAccount.email) != null)
                {
                    ModelState.AddModelError("", "Email đã được sử dụng");
                    return View(reqAccount);
                }
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
            return View(new EditAccount()
            {
                accountName = account.accountName,
                firstName = account.firstName,
                lastName = account.lastName,
                email = account.email,
                avar = account.avar
            });
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAccountProfile(string name, [Bind("accountName, firstName, lastName, email, avar")]EditAccount editAccount, IFormFile avarFile)
        {
            if(ModelState.IsValid)
            {
                if(name != HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserName").Value)
                {
                    return NotFound();
                }
                var account = _context.Accounts.FirstOrDefault(p => p.accountName == name);

                if(account == null)
                    return NotFound();

                if(avarFile != null && avarFile.Length > 0)
                {
                    var InputFileName = Utility.CreateMD5(account.accountName + account.ID + account.email);

                    var fileInfor = new FileInfo(avarFile.FileName);

                    if(fileInfor.Extension != ".jpg" && fileInfor.Extension != ".png")
                    {
                        ModelState.AddModelError("", "File ảnh không đúng định dạng");
                        return View(editAccount);
                    }

                    InputFileName += fileInfor.Extension;

                    var ServerSavePath = Path.Combine(_hostEnvironment.WebRootPath + "/UploadedFiles/Avars/" + InputFileName);

                    var stream = new FileStream(ServerSavePath, FileMode.Create);

                    await avarFile.CopyToAsync(stream);

                    stream.Close();

                    account.avar = "/UploadedFiles/Avars/" + InputFileName;
                }
            
                account.firstName = editAccount.firstName;
                account.lastName = editAccount.lastName;
                account.email = editAccount.email;

                editAccount.avar = account.avar;

                _context.Update(account);
                _context.SaveChanges();
            }

            return View(editAccount);
        }
        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangePassword([Bind("oldPassword", "newPassword", "confirmPassword")]ChangePassword item)
        {
            if(ModelState.IsValid)
            {
                var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);
                var account = _context.Accounts.FirstOrDefault(p => p.ID == accountID);

                if(account.passWord != Utility.CreateMD5(item.oldPassword))
                {
                    ModelState.AddModelError("", "Mật khẩu cũ không đúng");
                    return View(item);
                }

                if(item.confirmPassword != item.newPassword)
                {
                    ModelState.AddModelError("", "Mật khẩu không khớp");
                    return View(item);
                }

                account.passWord = Utility.CreateMD5(item.newPassword);
                _context.Update(account);

                _context.SaveChanges();

                return RedirectToAction("EditAccountProfile", new{name=account.accountName});
            }
            return View(item);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
