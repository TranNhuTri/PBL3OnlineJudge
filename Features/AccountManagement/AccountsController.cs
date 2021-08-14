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
using PBL3.Features.AccountManagement;
using PBL3.Features.SubmissionManagement;
using PBL3.Features.ProblemManagement;
using PBL3.Features.CommentManagement;
using PBL3.Features.ActionManagemant;

namespace PBL3.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AccountsController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ISubmissionService  _submissionService;
        private readonly IProblemService _problemService;
        private readonly ICommentService _commentService;
        private readonly IActionService _actionService;
        public AccountsController(IAccountService accountService, ISubmissionService  submissionService, IProblemService problemService, ICommentService commentService, IActionService actionService)
        {
            _accountService = accountService;
            _submissionService = submissionService;
            _problemService = problemService;
            _commentService = commentService;
            _actionService = actionService;
        }
        public IActionResult Index(int? page, int? isActived, int? roleID, string searchText)
        {
            var listAccounts = _accountService.GetAllAccounts().OrderBy(p => p.accountName).ToList();

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
                if(_accountService.GetAccountByAccountName(account.accountName) != null)
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

                _accountService.AddAccount(account);

                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }
        public IActionResult EditAccount(int id)
        {
            var account = _accountService.GetAccountByID(id);

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
        public IActionResult EditAccount(int id, [Bind("accountName", "email", "isActived", "roleID", "lastName", "firstName")] EditAccount reqEditAccount)
        {
            if(ModelState.IsValid)
            {
                var account = _accountService.GetAccountByID(id);

                if(_accountService.GetAllAccounts().FirstOrDefault(p => p.accountName == reqEditAccount.accountName && p.accountName != account.accountName) != null)
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

                _accountService.UpdateAccount(account);

                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult ChangePassword(int id)
        {
            var account = _accountService.GetAccountByID(id);
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
            var account = _accountService.GetAccountByID((int)id);

            account.passWord = Utility.CreateMD5(newPassword);

            _accountService.UpdateAccount(account);

            if(account == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(EditAccount), new{id = account.ID});
        }
        public IActionResult DeleteAccount(int id)
        {
            var account = _accountService.GetAccountByID(id);
            account.submissions = _submissionService.GetAllSubmissionsByAccountID(id);
            foreach(var item in account.submissions)
                item.problem = _problemService.GetProblemByID(item.problemID);
            account.comments =  _commentService.GetCommentsByAccountID(id);
            
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
            var account = _accountService.GetAccountByID((int)id);

            if(account == null)
            {
                return NotFound();
            }

            account.isDeleted = true;

            var listSubmissions = _submissionService.GetAllSubmissionsByAccountID((int)id);

            foreach(var item in listSubmissions)
            {
                item.isDeleted = true;
                _submissionService.ChangeIsDeleted(item.ID);
            }

            var listComments = _commentService.GetCommentsByAccountID((int)id);

            foreach(var item in listComments)
            {
                item.isDeleted = true;
                _commentService.ChangeIsDeletedComment(item.ID);
            }

            _accountService.UpdateAccount(account);

            _actionService.AddAction(new PBL3.Models.Action()
            {
                objectID = account.ID,
                accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value),
                action = "Xóa tài khoản",
                dateTime = DateTime.Now,
                typeObject = (int)TypeObject.Account
            });

            return RedirectToAction(nameof(Index));
        }
        public IActionResult DeletedAccounts()
        {
            var listAccounts = _accountService.GetAllDeletedAccounts();

            var listDates = new List<DateTime>();

            foreach(var item in listAccounts)
            {
                var action = _actionService.GetAllActions().Where(p => p.objectID == item.ID && p.typeObject == (int)TypeObject.Account).OrderByDescending(p => p.dateTime).First();
                listDates.Add(action.dateTime);
            }
            
            ViewBag.deleteDates = listDates;

            return View(listAccounts.ToList());
        }
        public IActionResult RestoreAccount(int id)
        {
            var account = _accountService.GetAccountByID(id);
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
            var account = _accountService.GetAccountByID((int)id);
            if(account == null)
            {
                return NotFound();
            }

            account.isDeleted = false;
            _accountService.UpdateAccount(account);

            var listSubmissions = _submissionService.GetAllSubmissionsByAccountID((int)id);

            foreach(var item in listSubmissions)
            {
                item.isDeleted = false;
                _submissionService.UpdateSubmission(item);
            }

            var listComments = _commentService.GetCommentsByAccountID((int)id);

            foreach(var item in listComments)
            {
                item.isDeleted = false;
                _commentService.UpdateComment(item);
            }

            return RedirectToAction(nameof(Index));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
