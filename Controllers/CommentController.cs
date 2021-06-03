using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PBL3.Models;
using PBL3.Data;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace PBL3.Controllers
{
    public class CommentController : Controller
    {
        private readonly PBL3Context _context;
        public CommentController(PBL3Context context)
        {
            _context = context;
        }
        public IActionResult GetComment(int id)
        {
            var comment = _context.Comments.Where(p => p.ID == id)
                                            .Include(p => p.account)
                                            .Include(p => p.child)
                                            .Include(p => p.likes)
                                            .ThenInclude(p => p.account)
                                            .FirstOrDefault(p => p.ID == id);
            if(comment == null)
                return NotFound();
            return View(comment);
        }
        [HttpPost]
        public IActionResult PostComment(int postID, string content, int? rootCommentID)
        {
            var account = _context.Accounts.FirstOrDefault(p => p.accountName == HttpContext.Session.GetString("AccountName"));
            var comment = new Comment()
            {
                content = content,
                timeCreate = DateTime.Now,
                postID = postID,
                accountID = account.ID,
            };

            _context.Add(comment);

            _context.SaveChanges();

            if(rootCommentID != null)
            {
                var parentComment = _context.Comments.Include(p => p.account).FirstOrDefault(p => p.ID == rootCommentID);
                if(parentComment != null)
                {
                    if(parentComment.level < 3)
                    {
                        comment.level = parentComment.level + 1;
                        comment.rootCommentID = rootCommentID;
                    }
                    else
                    {
                        comment.level = 3;
                        comment.rootCommentID = parentComment.rootCommentID;
                    }
                }

                if(account.ID != parentComment.accountID)
                {
                    var noti = new Notification()
                    {
                        content = "<b>" + account.accountName + "</b> đã trả lời bình luận của bạn",
                        timeCreate = DateTime.Now,
                        accountID = parentComment.accountID,
                        objectID = comment.ID,
                        typeNotification = _context.TypeNotifications.FirstOrDefault(p => p.name == "New Comment Reply")
                    };

                    _context.Update(parentComment.account);

                    _context.Add(noti);
                }
            }
            else
            {
                comment.level = 1;
                List<int> listAuthorIDs = new List<int>();
                if(_context.Articles.FirstOrDefault(p => p.ID == postID) != null)
                {
                    var article = _context.Articles.Include(p => p.articleAuthors).FirstOrDefault(p => p.ID == postID);
                    listAuthorIDs = article.articleAuthors.Where(p => p.isDeleted == false).Select(p => p.authorID).ToList();
                }
                else
                {
                    var problem = _context.Problems.Include(p => p.problemAuthors).FirstOrDefault(p => p.ID == postID);
                    listAuthorIDs = problem.problemAuthors.Where(p => p.isDeleted == false).Select(p => p.authorID).ToList();
                }

                foreach(int id in listAuthorIDs)
                {
                    if(listAuthorIDs.Contains(account.ID))
                        continue;
                    
                    var noti = new Notification()
                    {
                        content = "<b>" + account.accountName + "</b> đã bình luận đề bài của bạn",
                        timeCreate = DateTime.Now,
                        accountID = id,
                        objectID = comment.ID,
                        typeNotification = _context.TypeNotifications.FirstOrDefault(p => p.name == "New Problem Comment")
                    };

                    var acc = _context.Accounts.FirstOrDefault(p => p.ID == id);

                    _context.Update(acc);

                    _context.Add(noti);
                }
            }

            _context.Update(comment);

            _context.SaveChanges();
            
            return RedirectToAction(nameof(GetComment), new{id = comment.ID});
        }
        public IActionResult CommentChild(int id)
        {
            var listComment = _context.Comments.Where(p => p.rootCommentID == id)
                                                .Include(p => p.account)
                                                .Include(p => p.child)
                                                .Include(p => p.likes)
                                                .ThenInclude(p => p.account)
                                                .ToList();
            return View(listComment);
        }
        public void DeleteListComments(List<int> listCommentIds)
        {
            foreach(int id in listCommentIds)
            {
                var item = _context.Comments.Include(p => p.child).FirstOrDefault(p => p.ID == id);
                if(item.child.Count > 0)
                {
                    DeleteListComments(item.child.Select(p => p.ID).ToList());
                }

                item.isDeleted = true;
                _context.Update(item);

                var notification = _context.Notifications.FirstOrDefault(p => p.objectID == item.ID);

                if(notification != null)
                {
                    notification.isDeleted = true;
                    _context.Update(notification);
                }
            }
            return;
        }
        [HttpPost]
        public bool DeleteComment(int id)
        {
            var comment = _context.Comments.Include(p => p.child)
                                            .FirstOrDefault(p => p.ID == id);
            if(comment != null)
            {
                if(comment.child.Count > 0)
                {
                    DeleteListComments(comment.child.Select(p => p.ID).ToList());
                }
                var notification = _context.Notifications.FirstOrDefault(p => p.objectID == comment.ID);

                if(notification != null)
                {
                    notification.isDeleted = true;
                    _context.Update(notification);
                }
                
                comment.isDeleted = true;
                _context.Update(comment);

                _context.SaveChanges();

                return true;
            }
            return false;
        }
        public void LikeComment(int commentID)
        {
            var account = _context.Accounts.FirstOrDefault(p => p.accountName == HttpContext.Session.GetString("AccountName"));
            if(account == null)
            {
                return;
            }
            var accountReceiveNotiID = _context.Comments.FirstOrDefault(p => p.ID == commentID).accountID;
            var like = _context.Likes.FirstOrDefault(p => p.commentID == commentID && p.accountID == accountReceiveNotiID);
            if(like != null)
            {
                if(like.status == true)
                {
                    like.status = false;
                }
                else
                {
                    like.status = true;
                }
                _context.Update(like);
            }
            else
            {
                _context.Add(new Like()
                {
                    commentID = commentID,
                    accountID = account.ID,
                    status = true
                });
                if(account.ID != accountReceiveNotiID)
                {
                    var notification = _context.Notifications.Where(p => p.accountID == accountReceiveNotiID && p.objectID == commentID).Include(p => p.typeNotification).FirstOrDefault(p => p.typeNotification.name == "New Like Comment");
                    if(notification != null)
                    {
                        int numberLikes = _context.Likes.Where(p => p.commentID == commentID && p.status == true).ToList().Count();
                        if(numberLikes >= 1)
                        {
                            notification.content = "<b>" + account.accountName + "</b> và " + numberLikes.ToString() + " người khác đã thích bình luận của bạn";
                        }
                        else
                        {
                            notification.content = "<b>" + account.accountName + "</b> đã thích bình luận của bạn";
                        }
                        notification.timeCreate = DateTime.Now;
                        notification.seen = false;
                        _context.Update(notification);
                    }
                    else
                    {
                        var noti = new Notification()
                        {
                            accountID = accountReceiveNotiID,
                            objectID = commentID,
                            content = "<b>" + account.accountName + "</b> đã thích bình luận của bạn",
                            timeCreate = DateTime.Now,
                            typeNotification = _context.TypeNotifications.FirstOrDefault(p => p.name == "New Like Comment")
                        };
                        _context.Add(noti);
                    }
                }
            }
            _context.SaveChanges();
        }
        public int GetNumberLikesOfComment(int id)
        {
            var comment = _context.Comments.Where(p => p.ID == id).Include(p => p.likes).FirstOrDefault();
            if(comment == null || comment.likes.Where(p => p.status == true) == null)
                return 0;
            return comment.likes.Where(p => p.status == true).ToList().Count;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}