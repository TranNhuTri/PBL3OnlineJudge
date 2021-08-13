using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PBL3.Models;
using PBL3.Data;
using PBL3.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace PBL3.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly PBL3Context _context;
        public ArticlesController(PBL3Context context)
        {
            _context = context;
        }
        public IActionResult Index(string topic, int? page, string articleName, int? authorID)
        {
            var Topic = _context.Topics.FirstOrDefault(p => p.name == topic);
            if(Topic == null)
            {
                return NotFound();
            }
            ViewData["ListAuthors"] = _context.Accounts.Where(p => (p.roleID == 2 || p.roleID == 1) && p.isDeleted == false).OrderBy(p => p.accountName).ToList();

            ViewBag.topic = topic;

            var listArticles = _context.Articles.Where(p => p.topicID == Topic.ID && p.isDeleted == false && p.IsPublic == true).Include(p => p.articleAuthors).ThenInclude(p => p.author).OrderByDescending(p => p.timeCreate).ToList();
            
            var paramater = new Dictionary<string, string>();

            paramater.Add("topic", topic);

            if(!string.IsNullOrEmpty(articleName))
            {
                listArticles = listArticles.Where(p => p.title.ToLower().Contains(articleName.ToLower())).ToList();
                paramater.Add("articleName", articleName);
            }

            if(authorID != null)
            {
                listArticles = listArticles.Where(p => p.articleAuthors.Where(p => p.isDeleted == false).Select(p => p.authorID).ToList().Contains((int)authorID)).ToList();
                paramater.Add("authorID", authorID.ToString());
            }

            ViewBag.paginationParams = paramater;

            if(page == null)
            {
                page = 1;
            }
            
            int limit = Utility.limitData;

            int start = (int)(page - 1)*limit;

            ViewBag.currentPage = page;

            ViewBag.totalPage = (int)Math.Ceiling((float)listArticles.Count/limit);

            listArticles = listArticles.Skip(start).Take(limit).ToList();
            
            return View(listArticles);
        }
        public IActionResult Topics()
        {
            var listTopics = _context.Topics.Where(p => p.isDeleted == false).ToList();
            return View(listTopics);
        }
        public IActionResult Article(int id)
        {
            var article = _context.Articles.FirstOrDefault(p => p.ID == id);

            ViewData["ListComments"] = _context.Comments.Where(p => p.postID == id && p.level == 1 && p.isHidden == false && p.isDeleted == false && p.typePost == 2)
                                                        .Include(p => p.account)
                                                        .Include(p => p.child)
                                                        .Include(p => p.likes)
                                                        .ThenInclude(p => p.account).AsSplitQuery().OrderByDescending(p => p.timeCreate)
                                                        .ToList();

            if(article == null || article.isDeleted == true)
            {
                return NotFound();
            }

            return View(article);
        }
        [Authorize(Roles ="Admin, Author")]
        public IActionResult AddArticle()
        {
            ViewData["ListTopics"] = _context.Topics.OrderBy(p => p.name).ToList();

            ViewData["ListAuthors"] = _context.Accounts.Where(p => (p.roleID == 1 || p.roleID == 2) && p.isActived == true && p.isDeleted == false).ToList();

            return View();
        }
        [Authorize(Roles ="Admin, Author")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddArticle([Bind("title, content", "IsPublic")]Article article, int? topicID, List<int> reqListAuthorIds, string next)
        {
            ViewData["ListTopics"] = _context.Topics.Where(p => p.isDeleted == false).OrderBy(p => p.name).ToList();

            ViewData["ListAuthors"] = _context.Accounts.Where(p => (p.roleID == 1 || p.roleID == 2) && p.isActived == true && p.isDeleted == false).ToList();

            if(ModelState.IsValid)
            {
                if(topicID != 0)
                {
                    article.topicID = topicID;
                }

                article.timeCreate = DateTime.Now;
                
                _context.Add(article);

                foreach(int id in reqListAuthorIds)
                { 
                    _context.Add(new ArticleAuthor()
                    {
                        article = article,
                        authorID = id
                    });
                }
            
                _context.SaveChanges();

                var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);

                var action = new PBL3.Models.Action()
                {
                    account = _context.Accounts.FirstOrDefault(p => p.ID == accountID),
                    objectID = article.ID,
                    dateTime = DateTime.Now,
                    action = "Tạo mới",
                    typeObject = Convert.ToInt32(TypeObject.Article)
                };

                _context.Add(action);

                _context.SaveChanges();

                if(next == "edit")
                {
                    return RedirectToAction("EditArticle", "Articles", new {id = article.ID});
                }

                return RedirectToAction("Articles", "Admin");
            }
            return View(article);
        }
        [Authorize(Roles ="Admin, Author")]
        public IActionResult EditArticle(int id)
        {
            ViewData["ListTopics"] = _context.Topics.Where(p => p.isDeleted == false).OrderBy(p => p.name).ToList();

            ViewData["ListAuthors"] = _context.Accounts.Where(p => (p.roleID == 1 || p.roleID == 2) && p.isActived == true && p.isDeleted == false).ToList();

            ViewData["ListChosenAuthorIds"] = _context.ArticleAuthors.Where(p => p.articleID == id && p.isDeleted == false).Select(p => p.authorID).ToList();
            
            var article = _context.Articles.FirstOrDefault(p => p.ID == id);

            if(article == null)
            {
                return NotFound();
            }

            return View(article);
        }
        [Authorize(Roles ="Admin, Author")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditArticle(int? id, [Bind("title, content", "IsPublic")]Article reqArticle, int? topicID, List<int> reqListAuthorIds, string next)
        {
            ViewData["ListTopics"] = _context.Topics.OrderBy(p => p.name).ToList();

            ViewData["ListAuthors"] = _context.Accounts.Where(p => (p.roleID == 1 || p.roleID == 2) && p.isActived == true && p.isDeleted == false).ToList();

            ViewData["ListChosenAuthorIds"] = reqListAuthorIds;

            var article = _context.Articles.Where(p => p.ID == id).Include(p => p.articleAuthors).FirstOrDefault();

            if(article == null)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);

                var account = _context.Accounts.FirstOrDefault(p => p.ID == accountID);

                if(article.content != reqArticle.content)
                {
                    article.content = reqArticle.content;
                    _context.Add(new PBL3.Models.Action()
                    {
                        account = account,
                        objectID = (int)id,
                        dateTime = DateTime.Now,
                        action = "Sửa nội dung",
                        typeObject = Convert.ToInt32(TypeObject.Article)
                    });
                }
                if(article.title != reqArticle.title)
                {
                    article.title = reqArticle.title;
                    _context.Add(new PBL3.Models.Action()
                    {
                        account = account,
                        objectID = (int)id,
                        dateTime = DateTime.Now,
                        action = "Sửa tên bài viết",
                        typeObject = Convert.ToInt32(TypeObject.Article)
                    });
                }
                if(topicID != 0 && article.topicID != topicID)
                {
                    article.topicID = topicID;
                    _context.Add(new PBL3.Models.Action()
                    {
                        account = account,
                        objectID = (int)id,
                        dateTime = DateTime.Now,
                        action = "Sửa chủ đề",
                        typeObject = Convert.ToInt32(TypeObject.Article)
                    });
                }
                if(article.IsPublic != reqArticle.IsPublic)
                {
                    article.IsPublic = reqArticle.IsPublic;
                    _context.Add(new PBL3.Models.Action()
                    {
                        account = account,
                        objectID = (int)id,
                        dateTime = DateTime.Now,
                        action = "Sửa trạng thái",
                        typeObject = Convert.ToInt32(TypeObject.Article)
                    });
                }
                var listArticleAuthors = _context.ArticleAuthors.Where(p => p.articleID == (int)id && p.isDeleted == false);

                foreach(var item in listArticleAuthors)// old listArticleAuthors     new reqListAuthorIds
                {
                    //delete
                    if(reqListAuthorIds.Any(p => p == item.authorID) == false)
                    {
                        item.isDeleted = true;
                        _context.Update(item);
                    }
                }
                foreach(var item in reqListAuthorIds)
                {
                    //add
                    if(article.articleAuthors.Any(p => p.authorID == item) == false)
                    {
                        _context.Add(new ArticleAuthor()
                        {
                            authorID = item,
                            articleID = (int)id
                        });
                    }
                    else
                    {
                        var tmpt = article.articleAuthors.FirstOrDefault(p => p.authorID == item);
                        tmpt.isDeleted = false;
                        _context.Update(tmpt);
                    }
                }

                _context.Update(article);

                _context.SaveChanges();

                if(next == "edit")
                {
                    return RedirectToAction("EditArticle", "Articles", new {id = article.ID});
                }
                return RedirectToAction("Articles", "Admin");
            }

            return View(reqArticle);
        }
        [Authorize(Roles ="Admin, Author")]
        public IActionResult ArticleHistory(int id)
        {
            var article = _context.Articles.FirstOrDefault(p => p.ID == id);
            if(article == null)
            {
                return NotFound();
            }
            var listActions = _context.Actions.Where(p => p.objectID == id && p.typeObject == Convert.ToInt32(TypeObject.Article)).Include(p => p.account).OrderByDescending(p => p.dateTime).ToList();
            return View(listActions);
        }
        [Authorize(Roles ="Admin, Author")]
        public IActionResult DeletedArticles()
        {
            var articles = _context.Articles.Where(p => p.isDeleted == true).ToList();

            var listDates = new List<DateTime>();

            foreach(var item in articles)
            {
                var action = _context.Actions.Where(p => p.objectID == item.ID && p.typeObject == (int)TypeObject.Article).OrderByDescending(p => p.dateTime).First();
                listDates.Add(action.dateTime);
            }
            
            ViewBag.deleteDates = listDates;

            return View(articles);
        }
        [Authorize(Roles ="Admin, Author")]
        public IActionResult DeleteArticle(int id)
        {
            var article = _context.Articles.FirstOrDefault(p => p.ID == id);

            if(article == null)
            {
                return NotFound();
            }

            ViewBag.listComments = _context.Comments.Where(p => p.postID == id).Include(p => p.account).ToList();

            return View(article);
        }
        [Authorize(Roles ="Admin, Author")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteArticle(int? id)
        {
            var article = _context.Articles.FirstOrDefault(p => p.ID == id);

            if(article == null)
            {
                return NotFound();
            }

            article.isDeleted = true;

            _context.Update(article);

            var listComments = _context.Comments.Where(p => p.postID == id).Include(p => p.account).ToList();

            ViewBag.listComments = listComments;

            var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);

            _context.Add(new PBL3.Models.Action()
            {
                account = _context.Accounts.FirstOrDefault(p => p.ID == accountID),
                objectID = (int)id,
                dateTime = DateTime.Now,
                action = "Xóa bài viết",
                typeObject = Convert.ToInt32(TypeObject.Article)
            });

            _context.SaveChanges();

            return RedirectToAction("Articles", "Admin");
        }
        [Authorize(Roles ="Admin, Author")]
        public IActionResult RestoreArticle(int id)
        {
            var article = _context.Articles.FirstOrDefault(p => p.ID == id);

            if(article == null)
            {
                return NotFound();
            }

            ViewData["ListTopics"] = _context.Topics.Where(p => p.isDeleted == false).OrderBy(p => p.name).ToList();

            ViewData["ListAuthors"] = _context.Accounts.Where(p => (p.roleID == 1 || p.roleID == 2) && p.isActived == true && p.isDeleted == false).ToList();

            ViewData["ListChosenAuthorIds"] = _context.ArticleAuthors.Where(p => p.articleID == id && p.isDeleted == false).Select(p => p.authorID).ToList();

            return View(article);
        }
        [Authorize(Roles ="Admin, Author")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RestoreArticle(int? id)
        {
            var article = _context.Articles.FirstOrDefault(p => p.ID == id);

            if(article == null)
            {
                return NotFound();
            }

            article.isDeleted = false;

            _context.Update(article);

            _context.SaveChanges();
            
            return RedirectToAction("Articles", "Admin");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
