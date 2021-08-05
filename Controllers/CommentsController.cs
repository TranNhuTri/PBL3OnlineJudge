using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PBL3.Models;
using PBL3.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using PBL3.General;

namespace PBL3.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private readonly PBL3Context _context;
        public CommentsController(PBL3Context context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index(int? page, int? isHidden, string searchText)
        {
            var listComments = _context.Comments.Where(p => p.isDeleted == false).Include(p => p.account).ToList();

            var paramater = new Dictionary<string, string>();

            if(isHidden != null)
            {
                if(isHidden == 1)
                {
                    listComments =  listComments.Where(p => p.isHidden == true)
                                                .ToList();
                }
                else
                    if(isHidden == 0)
                    {
                        listComments =  listComments.Where(problem => problem.isHidden == false)
                                                    .ToList();
                    }
                paramater.Add("isHidden", isHidden.ToString());
            }

            if(!string.IsNullOrEmpty(searchText))
            {
                paramater.Add("searchText", searchText);
                searchText = searchText.ToLower();
                var tmpt = new List<Comment>();
                foreach(var item in listComments)
                {
                    var postName = item.typePost == 1 ? _context.Problems.FirstOrDefault(p => p.ID == item.postID).title : _context.Articles.FirstOrDefault(p => p.ID == item.postID).title;
                    if(item.account.accountName.ToLower().Contains(searchText) || item.content.ToLower().Contains(searchText) || postName.ToLower().Contains(searchText))
                    {
                        tmpt.Add(item);
                    }
                }
                listComments = tmpt;
            }


            if(page == null)
            {
                page = 1;
            }

            int limit = Utility.limitData;
            int start = (int)(page - 1)*limit;

            ViewBag.currentPage = page;

            ViewBag.totalPage = (int)Math.Ceiling((float)listComments.Count/limit);

            listComments = listComments.Skip(start).Take(limit).ToList();

            ViewBag.postName = new List<string>();

            foreach(var item in listComments)
            {
                if(item.typePost == 1)
                {
                    ViewBag.postName.Add(_context.Problems.FirstOrDefault(p => p.ID == item.postID).title);
                }
                else
                {
                    ViewBag.postName.Add(_context.Articles.FirstOrDefault(p => p.ID == item.postID).title);
                }
            }

            return View(listComments);
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
            var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);

            int typePost = 0;
            if(_context.Problems.FirstOrDefault(p => p.ID == postID) != null)
            {
                typePost = 1;
            }
            else
            {
                typePost = 2;
            }
            var comment = new Comment()
            {
                content = content,
                timeCreate = DateTime.Now,
                postID = postID,
                accountID = accountID,
                typePost = typePost
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

                if(accountID != parentComment.accountID)
                {
                    var noti = new Notification()
                    {
                        content = "<b>" + HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserName").Value + "</b> đã trả lời bình luận của bạn",
                        timeCreate = DateTime.Now,
                        accountID = parentComment.accountID,
                        objectID = comment.ID,
                        typeNotification = Convert.ToInt32(TypeNotification.NewCommentReply)
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
                    if(listAuthorIDs.Contains(accountID))
                        continue;
                    
                    var noti = new Notification()
                    {
                        content = "<b>" + HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserName").Value + "</b> đã bình luận đề bài của bạn",
                        timeCreate = DateTime.Now,
                        accountID = id,
                        objectID = comment.ID,
                        typeNotification = Convert.ToInt32(TypeNotification.NewProblemComment)
                    };

                    _context.Add(noti);
                }
            }

            _context.Update(comment);

            _context.SaveChanges();
            
            return RedirectToAction(nameof(GetComment), new{id = comment.ID});
        }
        public IActionResult CommentChild(int id)
        {
            var listComment = _context.Comments.Where(p => p.rootCommentID == id && p.isDeleted == false && p.isHidden == false)
                                                .Include(p => p.account)
                                                .Include(p => p.child)
                                                .Include(p => p.likes)
                                                .ToList();
            return View(listComment);
        }
        [Authorize(Roles ="Admin")]
        public IActionResult EditComment(int id)
        {
            var comment = _context.Comments.Where(p => p.ID == id).Include(p => p.account).FirstOrDefault();

            if(comment == null)
            {
                return NotFound();
            }

            if(comment.typePost == 1)
            {
                ViewBag.postName = _context.Problems.FirstOrDefault(p => p.ID == comment.postID).title;
            }
            else
            {
                ViewBag.postName = _context.Articles.FirstOrDefault(p => p.ID == comment.postID).title;
            }

            ViewBag.commentLikes = _context.Likes.Where(p => p.commentID == comment.ID && p.status == true).ToList().Count;

            return View(comment);
        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditComment(int? id, [Bind("content", "isHidden")]Comment reqComment, string next)
        {
            if(id == null)
            {
                return NotFound();
            }

            var comment = _context.Comments.Where(p => p.ID == id).FirstOrDefault();
            if(comment == null)
            {
                return NotFound();
            }

            comment.account = _context.Accounts.FirstOrDefault(p => p.ID == comment.accountID);

            if(string.IsNullOrEmpty(reqComment.content))
            {
                return View(comment);
            }

            comment.isHidden = reqComment.isHidden;

            comment.content = reqComment.content;

            _context.Update(comment);

            _context.SaveChanges();

            if(comment.typePost == 1)
            {
                ViewBag.postName = _context.Problems.FirstOrDefault(p => p.ID == comment.postID).title;
            }
            else
            {
                ViewBag.postName = _context.Articles.FirstOrDefault(p => p.ID == comment.postID).title;
            }

            ViewBag.commentLikes = _context.Likes.Where(p => p.commentID == comment.ID && p.status == true).ToList().Count;
            
            if(next == "edit")
                return View(comment);
            return RedirectToAction("Index");
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
        [Authorize]
        [HttpPost]
        public bool DeleteCommentAPI(int id)
        {
            var comment = _context.Comments.Include(p => p.child)
                                            .FirstOrDefault(p => p.ID == id);
            if(comment != null)
            {
                if(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "Role").Value == "Admin" || Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value) == comment.accountID)
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
            }
            return false;
        }
        [Authorize]
        public IActionResult DeleteComment(int id)
        {
            if(DeleteCommentAPI(id))
                return RedirectToAction(nameof(Index));
            return RedirectToAction("EditComment", new {id = id});
        }
        [Authorize]
        public void LikeComment(int commentID)
        {
            var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);

            var accountName = HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserName").Value;

            var accountReceiveNotiID = _context.Comments.FirstOrDefault(p => p.ID == commentID).accountID;

            var like = _context.Likes.FirstOrDefault(p => p.commentID == commentID && p.accountID == accountID);
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
                    accountID = accountID,
                    status = true
                });
                if(accountID != accountReceiveNotiID)
                {
                    var notification = _context.Notifications.Where(p => p.accountID == accountReceiveNotiID && p.objectID == commentID).FirstOrDefault(p => p.typeNotification == Convert.ToInt32(TypeNotification.NewCommentLike));
                    if(notification != null)
                    {
                        int numberLikes = _context.Likes.Where(p => p.commentID == commentID && p.status == true).ToList().Count();
                        if(numberLikes >= 1)
                        {
                            notification.content = "<b>" + accountName + "</b> và " + numberLikes.ToString() + " người khác đã thích bình luận của bạn";
                        }
                        else
                        {
                            notification.content = "<b>" + accountName + "</b> đã thích bình luận của bạn";
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
                            content = "<b>" + accountName + "</b> đã thích bình luận của bạn",
                            timeCreate = DateTime.Now,
                            typeNotification = Convert.ToInt32(TypeNotification.NewCommentLike)
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
        [Authorize(Roles ="Admin")]
        public IActionResult DeletedComments()
        {
            var listComments = _context.Comments.Where(p => p.isDeleted == true).Include(p => p.account).ToList();

            ViewBag.postName = new List<string>();

            foreach(var item in listComments)
            {
                if(item.typePost == 1)
                {
                    ViewBag.postName.Add(_context.Problems.FirstOrDefault(p => p.ID == item.postID).title);
                }
                else
                {
                    ViewBag.postName.Add(_context.Articles.FirstOrDefault(p => p.ID == item.postID).title);
                }
            }

            return View(listComments);
        }
        [Authorize(Roles ="Admin")]
        public IActionResult RestoreComment(int id)
        {
            var comment = _context.Comments.Where(p => p.ID == id).Include(p => p.account).FirstOrDefault();
            if(comment == null)
                return NotFound();
                
            if(comment.typePost == 1)
            {
                ViewBag.postName = _context.Problems.FirstOrDefault(p => p.ID == comment.postID).title;
            }
            else
            {
                ViewBag.postName = _context.Articles.FirstOrDefault(p => p.ID == comment.postID).title;
            }

            ViewBag.commentLikes = _context.Likes.Where(p => p.commentID == comment.ID && p.status == true).ToList().Count;

            return View(comment);
        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RestoreComment(int? id)
        {
            var comment = _context.Comments.FirstOrDefault(p => p.ID == id);
            if(comment == null)
            {
                return NotFound();
            }
            comment.isDeleted = false;
            _context.Update(comment);
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
