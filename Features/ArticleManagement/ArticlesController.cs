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
using PBL3.Features.TopicManagement;
using PBL3.Features.AccountManagement;
using PBL3.Repositories;
using PBL3.Features.ActionManagemant;
using PBL3.Features.CommentManagement;

namespace PBL3.Features.ArticleManagement
{
    public class ArticlesController : Controller
    {
        private readonly ITopicService _topicService;
        private readonly IArticleService _articleService;
        private readonly IAccountService _accountService;
        private readonly IRepository<ArticleAuthor> _articleAuthorRepo;
        private readonly IActionService _actionService;
        private readonly ICommentService _commentService;
        public ArticlesController(ITopicService topicService, IArticleService articleService, IAccountService accountService
        ,IRepository<ArticleAuthor> articleAuthorRepo, IActionService actionService, ICommentService commentService)
        {
            _topicService = topicService;
            _articleService = articleService;
            _accountService = accountService;
            _articleAuthorRepo = articleAuthorRepo;
            _actionService = actionService;
            _commentService = commentService;
        }
        public IActionResult Topics()
        {
            var listTopics = _topicService.GetAllTopics();
            return View(listTopics);
        }
        public IActionResult Index(string topicName, int? page, string articleName, int? authorID)
        {
            var topic = _topicService.GetAllTopics().FirstOrDefault(p => p.name == topicName);
            if (topic == null)
                return NotFound();

            ViewData["ListAuthors"] = _accountService.GetAllAuthor();
            ViewBag.topic = topic;

            var listArt = _articleService.GetArticlesByTopicID(topic.ID)
            .OrderByDescending(p => p.timeCreate).ToList();
            List<Article> listArticles = new List<Article>();
            foreach(Article article in listArt)
            {
                article.articleAuthors = _articleAuthorRepo.GetAll().Where(p => p.articleID == article.ID).ToList();
                bool checkAuthor = false;
                if (authorID == null || article.articleAuthors.Select(p => p.articleID).ToList().Contains((int)authorID))
                    checkAuthor = true;
                bool checkTitle = false;
                if (string.IsNullOrEmpty(articleName) || article.title.ToLower().Contains(articleName.ToLower()))
                    checkTitle = true;
                if (checkAuthor && checkTitle)
                listArticles.Add(article);
            }

            var paramater = new Dictionary<string, string>();
            paramater.Add("topic", topicName);
            if (!string.IsNullOrEmpty(articleName))
                paramater.Add("articleName", articleName);
            if (authorID != null)
                paramater.Add("authorID", authorID.ToString());
            ViewBag.paginationParams = paramater;

            if(page == null) page = 1;
            int limit = Utility.limitData;
            int start = (int)(page - 1)*limit;
            ViewBag.currentPage = page;
            ViewBag.totalPage = (int)Math.Ceiling((float)listArticles.Count/limit);
            listArticles = listArticles.Skip(start).Take(limit).ToList();    
            return View(listArticles);
        }
        
        public IActionResult Article(int id)
        {
            var article = _articleService.GetArticleByID(id);
            ViewData["ListComments"] = _commentService.GetCommentsByArticleID(id);
            if(article == null || article.isDeleted == true)
                return NotFound();
            return View(article);
        }
        [Authorize(Roles ="Admin, Author")]
        public IActionResult AddArticle()
        {
            ViewData["ListTopics"] = _topicService.GetAllTopics().OrderBy(p => p.name).ToList();
            ViewData["ListAuthors"] = _accountService.GetAllAuthor();

            return View();
        }
        [Authorize(Roles ="Admin, Author")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddArticle([Bind("title, content", "IsPublic")]Article article, int? topicID, List<int> reqListAuthorIds, string next)
        {
            ViewData["ListTopics"] = _topicService.GetAllTopics().OrderBy(p => p.name);

            ViewData["ListAuthors"] = _accountService.GetAllAuthor();

            if(ModelState.IsValid)
            {
                if(topicID != 0)
                    article.topicID = topicID;
                article.timeCreate = DateTime.Now;
               _articleService.AddArticle(article);

                foreach(int id in reqListAuthorIds)
                { 
                    _articleAuthorRepo.Insert(new ArticleAuthor()
                    {
                        article = article,
                        authorID = id
                    });
                }

                var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);
                var action = new PBL3.Models.Action()
                {
                    account = _accountService.GetAccountByID(accountID),
                    objectID = article.ID,
                    dateTime = DateTime.Now,
                    action = "Tạo mới",
                    typeObject = Convert.ToInt32(TypeObject.Article)
                };

                _actionService.AddAction(action);

                if(next == "edit") return RedirectToAction("EditArticle", "Articles", new {id = article.ID});
                return RedirectToAction("Articles", "Admin");
            }
            return View(article);
        }
        [Authorize(Roles ="Admin, Author")]
        public IActionResult EditArticle(int id)
        {
            ViewData["ListTopics"] = _topicService.GetAllTopics().OrderBy(p => p.name);
            ViewData["ListAuthors"] = _accountService.GetAllAuthor();
            ViewData["ListChosenAuthorIds"] = _articleAuthorRepo.GetAll().Where(p => p.articleID == id && p.isDeleted == false)
            .Select(p => p.authorID).ToList();
            
            var article = _articleService.GetArticleByID(id);
            if(article == null) return NotFound();
            return View(article);
        }
        [Authorize(Roles ="Admin, Author")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditArticle(int? id, [Bind("title, content", "IsPublic")]Article reqArticle, int? topicID, List<int> reqListAuthorIds, string next)
        {
            ViewData["ListTopics"] = _topicService.GetAllTopics().OrderBy(p => p.name);
            ViewData["ListAuthors"] = _accountService.GetAllAuthor();
            ViewData["ListChosenAuthorIds"] = reqListAuthorIds;

            var article = _articleService.GetArticleByID((int)id);
            article.articleAuthors = _articleAuthorRepo.GetAll().Where(p => p.articleID == article.ID).ToList();
            if(article == null) return NotFound();

            if(ModelState.IsValid)
            {
                var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);
                var account = _accountService.GetAccountByID(accountID);
                if(article.content != reqArticle.content)
                {
                    article.content = reqArticle.content;
                    _actionService.AddAction(new PBL3.Models.Action()
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
                    _actionService.AddAction(new PBL3.Models.Action()
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
                    _actionService.AddAction(new PBL3.Models.Action()
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
                    _actionService.AddAction(new PBL3.Models.Action()
                    {
                        account = account,
                        objectID = (int)id,
                        dateTime = DateTime.Now,
                        action = "Sửa trạng thái",
                        typeObject = Convert.ToInt32(TypeObject.Article)
                    });
                }
                var listArticleAuthors = _articleAuthorRepo.GetAll().Where(p => p.articleID == (int)id && p.isDeleted == false);

                foreach(var item in listArticleAuthors)// old listArticleAuthors     new reqListAuthorIds
                {
                    if(reqListAuthorIds.Any(p => p == item.authorID) == false)
                    {
                        item.isDeleted = true;
                        _articleAuthorRepo.Update(item);
                    }
                }
                foreach(var item in reqListAuthorIds)
                {
                    //add
                    if(article.articleAuthors.Any(p => p.authorID == item) == false)
                    {
                        _articleAuthorRepo.Insert(new ArticleAuthor()
                        {
                            authorID = item,
                            articleID = (int)id
                        });
                    }
                    else
                    {
                        var tmpt = article.articleAuthors.FirstOrDefault(p => p.authorID == item);
                        tmpt.isDeleted = false;
                        _articleAuthorRepo.Update(tmpt);
                    }
                }

                _articleService.UpdateArticle(article);

                if(next == "edit") return RedirectToAction("EditArticle", "Articles", new {id = article.ID});
                return RedirectToAction("Articles", "Admin");
            }
            return View(reqArticle);
        }
        [Authorize(Roles ="Admin, Author")]
        public IActionResult ArticleHistory(int id)
        {
            var article = _articleService.GetArticleByID(id);
            if(article == null) return NotFound();
            var listActions = _actionService.GetActionsByArticleID(id).OrderByDescending(p => p.dateTime).ToList();
            List<PBL3.Models.Action> listActionsIncludeAccount = new List<PBL3.Models.Action>();
            foreach (PBL3.Models.Action item in listActions)
            {
                item.account = _accountService.GetAccountByID(item.accountID);
                listActionsIncludeAccount.Add(item);
            }
            return View(listActions);
        }
        [Authorize(Roles ="Admin, Author")]
        public IActionResult DeletedArticles()
        {
            var articles = _articleService.GetAllDeletedArticles();
            var listDates = new List<DateTime>();
            foreach(var item in articles)
            {
                var action = _actionService.GetActionsByArticleID(item.ID).OrderByDescending(p => p.dateTime).First();
                listDates.Add(action.dateTime);
            }
            ViewBag.deleteDates = listDates;
            return View(articles);
        }
        [Authorize(Roles ="Admin, Author")]
        public IActionResult DeleteArticle(int id)
        {
            var article = _articleService.GetArticleByID(id);
            if(article == null) return NotFound();
            var listComments = _commentService.GetCommentsByArticleID(id).ToList();
            List<Comment> listCommentsIncludeAccount = new List<Comment>();
            foreach (Comment item in listComments)
            {
                item.account = _accountService.GetAccountByID(item.accountID);
                listCommentsIncludeAccount.Add(item);
            }
            ViewBag.listComments = listCommentsIncludeAccount;
            return View(article);
        }
        [Authorize(Roles ="Admin, Author")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteArticle(int? id)
        {
            var article = _articleService.GetArticleByID((int)id);

            if(article == null) return NotFound();
            _articleService.ChangeIsDeletedArticle((int)id);

            var listComments = _commentService.GetCommentsByArticleID((int)id).ToList();
            List<Comment> listCommentsIncludeAccount = new List<Comment>();
            foreach (Comment item in listComments)
            {
                item.account = _accountService.GetAccountByID(item.accountID);
                listCommentsIncludeAccount.Add(item);
            }
            ViewBag.listComments = listCommentsIncludeAccount;

            var accountID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(p => p.Type == "UserID").Value);
            _actionService.AddAction(new PBL3.Models.Action()
            {
                account = _accountService.GetAccountByID(accountID),
                objectID = (int)id,
                dateTime = DateTime.Now,
                action = "Xóa bài viết",
                typeObject = Convert.ToInt32(TypeObject.Article)
            });
            return RedirectToAction("Articles", "Admin");
        }
        [Authorize(Roles ="Admin, Author")]
        public IActionResult RestoreArticle(int id)
        {
            var article = _articleService.GetArticleByID((int)id);
            if(article == null) return NotFound();

            ViewData["ListTopics"] = _topicService.GetAllTopics().OrderBy(p => p.name);
            ViewData["ListAuthors"] = _accountService.GetAllAuthor();
            ViewData["ListChosenAuthorIds"] = _articleAuthorRepo.GetAll().Where(p => p.articleID == id && p.isDeleted == false).Select(p => p.authorID).ToList();
            return View(article);
        }
        [Authorize(Roles ="Admin, Author")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RestoreArticle(int? id)
        {
            var article = _articleService.GetArticleByID((int)id);
            if(article == null)
                return NotFound();
            _articleService.ChangeIsDeletedArticle((int)id);
            return RedirectToAction("Articles", "Admin");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
