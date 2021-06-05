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
    public class AccountsController : Controller
    {
        private readonly PBL3Context _context;
        public AccountsController(PBL3Context context)
        {
            _context = context;
        }
        public IActionResult Index(int? page, int? isActived, int? typeAccount, string searchText)
        {
            var listAccounts = _context.Accounts.OrderBy(p => p.accountName).ToList();

            var paramater = new Dictionary<string, string>();

            if(typeAccount != null)
            {
                listAccounts = listAccounts.Where(p => p.typeAccount == typeAccount).ToList();
                paramater.Add("typeAccount", typeAccount.ToString());
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
        public IActionResult EditAccount(int id)
        {
            var account = _context.Accounts.FirstOrDefault(p => p.ID == id);

            if(account == null)
            {
                return NotFound();
            }

            return View(new EditAccount()
            {
                accountName = account.accountName,
                email = account.email,
                typeAccount = account.typeAccount,
                isActived = account.isActived,
                lastName = account.lastName,
                firstName = account.firstName
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAccount(int id, [Bind("accountName", "email", "isActived", "typeAccount", "lastName", "firstName")] EditAccount reqEditAccount)
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
                account.typeAccount = reqEditAccount.typeAccount;
                account.lastName = reqEditAccount.lastName;
                account.firstName = reqEditAccount.firstName;

                _context.Update(account);
                await _context.SaveChangesAsync();

                return RedirectToAction("ListAccounts");
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
