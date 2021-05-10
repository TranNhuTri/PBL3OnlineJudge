using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PBL3.Models;
using PBL3.Data;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Security.Cryptography;

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
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("UserName", string.Empty);
            return RedirectToAction("Index", "Home");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("UserName, PassWord")]LoginUser user)
        {
            if(ModelState.IsValid)
            {
                var User = _context.User.FirstOrDefault(m => m.UserName == user.UserName && m.PassWord == user.PassWord && m.Actived == true);
                if(User != null)
                {
                    HttpContext.Session.SetString("UserName", User.UserName);
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
        public static string Encrypt(string text)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }

        public static string Decrypt(string cipher)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipher);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return UTF8Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp([Bind("UserName", "PassWord", "Email")]User User, string ConfirmPassword, string LastName, string FirstName)
        {
            if(ModelState.IsValid)
            {
                var user = _context.User.FirstOrDefault(a => a.UserName == User.UserName);
                if(user != null)
                {
                    return NotFound();
                }
                if(!String.IsNullOrEmpty(User.Email))
                {
                    User.TimeCreate = DateTime.Now;
                    User.Token = Encrypt(User.UserName);
                    User.TypeAccount = 3;

                    _context.User.Add(User);
                    _context.SaveChangesAsync();

                    var smtpClient = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential("CodeTop1.Net@gmail.com", "codetop1"),
                        EnableSsl = true,
                    };
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("CodeTop1.Net@gmail.com"),
                        Subject = "Wellcome to CodeTop1",
                        Body = "Chào mừng bạn đến với CodeTop1. Nhấn vào đường link sau để xác thực email ! https://localhost:5001/Account/VerifyMail?token=" + User.Token + "&&Email=" + User.Email,
                    };
                    mailMessage.To.Add(User.Email);
                    smtpClient.Send(mailMessage);
                }
            }
            return View();
        }
        public IActionResult VerifyMail(string token, string Email)
        {
            var User = (from acc in _context.User where acc.UserName == Decrypt(token) && acc.Email == Email select acc).FirstOrDefault();
            if(User != null)
            {
                if(DateTime.Compare(User.TimeCreate.AddHours(4), DateTime.Now) >= 0)
                {
                    User.Actived = true;
                    _context.Update(User);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    _context.User.Remove(User);
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
