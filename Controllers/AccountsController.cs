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
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace PBL3.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AccountsController : Controller
    {
        private readonly PBL3Context _context;
        public AccountsController(PBL3Context context)
        {
            _context = context;
        }
        public IActionResult Index(int? page, int? isActived, int? roleID, string searchText)
        {
            var listAccounts = _context.Accounts.Where(p => p.isDeleted == false).OrderBy(p => p.accountName).ToList();

            var paramater = new Dictionary<string, string>();

            if(roleID != null)
            {
                listAccounts = listAccounts.Where(p => p.roleID == roleID).ToList();
                paramater.Add("roleID", roleID.ToString());
            }
            if(isActived != null)
            {
                if(isActived == 1)
                {
                    listAccounts = listAccounts.Where(p => p.isActived == true).ToList();
                }
                else
                    if(isActived == 0)
                    {
                        listAccounts = listAccounts.Where(p => p.isActived == false).ToList();
                    }
                paramater.Add("isActived", isActived.ToString());
            }
            if(!string.IsNullOrEmpty(searchText))
            {
                listAccounts = listAccounts.Where(p => p.accountName.ToLower().Contains(searchText.ToLower()) || p.email.ToLower().Contains(searchText.ToLower()) || (p.lastName + " " + p.firstName).ToLower().Contains(searchText.ToLower())).ToList();
                paramater.Add("searchText", searchText);
            }

            ViewBag.paginationParams = paramater;

            if(page == null)
                page = 1;
            
            int limit = Utility.limitData;

            int start = (int)(page - 1)*limit;

            ViewBag.currentPage = page;

            ViewBag.totalPage = (int)Math.Ceiling((float)listAccounts.Count/limit);

            listAccounts = listAccounts.Skip(start).Take(limit).ToList();

            return View(listAccounts);
        }
        public IActionResult AddAccount()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAccount([Bind("accountName, passWord, lastName, firstName, email")]Account account, string confirmPassWord)
        {
            if(ModelState.IsValid)
            {
                if(_context.Accounts.FirstOrDefault(p => p.accountName == account.accountName) != null)
                {
                    ModelState.AddModelError("", "Tên tài khoản đã tồn tại");
                    return View();
                }
                if(account.passWord != confirmPassWord)
                {
                    ModelState.AddModelError("", "Mật khẩu không khớp nhau");
                    return View();
                }
                account.roleID = 3;
                account.passWord = Utility.CreateMD5(account.passWord);
                account.timeCreate = DateTime.Now;

                _context.Add(account);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }
        public IActionResult EditAccount(int id)
        {
            var account = _context.Accounts.FirstOrDefault(p => p.ID == id);

            if(account == null)
            {
                return NotFound();
            }

            return View(new EditAccount()
            {
                ID = id,
                accountName = account.accountName,
                email = account.email,
                roleID = account.roleID,
                isActived = account.isActived,
                lastName = account.lastName,
                firstName = account.firstName,
                timeCreate = account.timeCreate
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAccount(int id, [Bind("accountName", "email", "isActived", "roleID", "lastName", "firstName")] EditAccount reqEditAccount)
        {
            if(ModelState.IsValid)
            {
                var account = _context.Accounts.FirstOrDefault(p => p.ID == id);

                if(_context.Accounts.FirstOrDefault(p => p.accountName == reqEditAccount.accountName && p.accountName != account.accountName) != null)
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                    return View();
                }

                account.accountName = reqEditAccount.accountName;
                account.email = reqEditAccount.email;
                account.isActived = reqEditAccount.isActived;
                account.roleID = reqEditAccount.roleID;
                account.lastName = reqEditAccount.lastName;
                account.firstName = reqEditAccount.firstName;

                _context.Update(account);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult ChangePassword(int id)
        {
            var account = _context.Accounts.FirstOrDefault(p => p.ID == id);
            if(account == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangePassword(int? id, string newPassword, string confirmPassWord)
        {
            if(id == null)
            {
                return NotFound();
            }

            if(string.IsNullOrEmpty(newPassword))
            {
                ModelState.AddModelError("", "Bạn cần nhập mật khẩu mới");
                return View();
            }
            if(string.IsNullOrEmpty(confirmPassWord))
            {
                ModelState.AddModelError("", "Bạn cần xác nhận lại mật khẩu");
                return View();
            }
            if(newPassword != confirmPassWord)
            {
                ModelState.AddModelError("", "Mật khẩu không khớp");
                return View();
            }
            var account = _context.Accounts.FirstOrDefault(p => p.ID == id);

            account.passWord = Utility.CreateMD5(newPassword);

            _context.Update(account);

            _context.SaveChanges();

            if(account == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(EditAccount), new{id = account.ID});
        }
        public IActionResult DeleteAccount(int id)
        {
            var account = _context.Accounts.Where(p => p.ID == id).Include(p => p.submissions).ThenInclude(p => p.problem).Include(p => p.comments).FirstOrDefault();
            
            var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);
            if(account == null || accountID == id)
            {
                return NotFound();
            }
            return View(account);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAccount(int? id)
        {
            var account = _context.Accounts.Where(p => p.ID == id).Include(p => p.submissions).ThenInclude(p => p.problem).FirstOrDefault();

            if(account == null)
            {
                return NotFound();
            }

            account.isDeleted = true;

            var listSubmissions = _context.Submissions.Where(p => p.accountID == id && p.isDeleted == false);

            foreach(var item in listSubmissions)
            {
                item.isDeleted = true;
                _context.Update(item);
            }

            var listComments = _context.Comments.Where(p => p.accountID == id && p.isDeleted == false);

            foreach(var item in listComments)
            {
                item.isDeleted = true;
                _context.Update(item);
            }

            _context.Update(account);

            _context.Add(new PBL3.Models.Action()
            {
                objectID = account.ID,
                accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value),
                action = "Xóa tài khoản",
                dateTime = DateTime.Now,
                typeObject = (int)TypeObject.Account
            });

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult DeletedAccounts()
        {
            var listAccounts = _context.Accounts.Where(p => p.isDeleted == true);

            var listDates = new List<DateTime>();

            foreach(var item in listAccounts)
            {
                var action = _context.Actions.Where(p => p.objectID == item.ID && p.typeObject == (int)TypeObject.Account).OrderByDescending(p => p.dateTime).First();
                listDates.Add(action.dateTime);
            }
            
            ViewBag.deleteDates = listDates;

            return View(listAccounts.ToList());
        }
        public IActionResult RestoreAccount(int id)
        {
            var account = _context.Accounts.FirstOrDefault(p => p.ID == id && p.isDeleted == true);
            if(account == null)
            {
                return NotFound();
            }
            return View(account);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RestoreAccount(int? id)
        {
            var account = _context.Accounts.FirstOrDefault(p => p.ID == id && p.isDeleted == true);
            if(account == null)
            {
                return NotFound();
            }

            account.isDeleted = false;
            _context.Update(account);

            var listSubmissions = _context.Submissions.Where(p => p.accountID == id && p.isDeleted == true);

            foreach(var item in listSubmissions)
            {
                item.isDeleted = false;
                _context.Update(item);
            }

            var listComments = _context.Comments.Where(p => p.accountID == id && p.isDeleted == true);

            foreach(var item in listComments)
            {
                item.isDeleted = false;
                _context.Update(item);
            }

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
