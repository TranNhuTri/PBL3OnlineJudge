using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PBL3.Models;
using PBL3.Data;
using Microsoft.EntityFrameworkCore;

namespace PBL3.Controllers
{
    public class NotificationController : Controller
    {
        private readonly PBL3Context _context;
        public NotificationController(PBL3Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public int GetNumberUnSeenNotification(string accountName)
        {
            var account = _context.Accounts.Include(p => p.notifications).FirstOrDefault(p => p.accountName == accountName);
            if(account == null)
                return -1;
            return account.notifications.Where(p => p.seen == false).ToList().Count;
        }

        public IActionResult ListNotifications(string accountName)
        {
            var account = _context.Accounts.Include(p => p.notifications).FirstOrDefault(p => p.accountName == accountName);
            if(account == null)
                return NotFound();
            return View(account.notifications.Where(p => p.seen == false).OrderByDescending(p => p.timeCreate).Take(10).ToList());
        }
        public IActionResult ViewNotification(int id)
        {
            var notication = _context.Notifications.FirstOrDefault(p => p.ID == id);

            notication.seen = true;
            _context.SaveChanges();

            var tmpt = _context.Comments.FirstOrDefault(p => p.ID == notication.objectID);
            if(tmpt != null)
            {
                if(_context.Problems.FirstOrDefault(p => p.ID == tmpt.postID) != null)
                {
                    return RedirectToAction("Problem", "Problems", new{id = tmpt.postID});
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                if(_context.Problems.FirstOrDefault(p => p.ID == notication.objectID) != null)
                {
                    return RedirectToAction("Problem", "Problems", new{id = notication.objectID});
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
