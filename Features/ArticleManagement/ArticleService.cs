using System;
using System.Collections.Generic;
using System.Linq;
using PBL3.Features.ActionManagemant;
using PBL3.General;
using PBL3.Models;
using PBL3.Repositories;

namespace PBL3.Features.ArticleManagement
{
    public class ArticleService: IArticleService
    {
        private readonly IRepository<Article> _articleRepo;

        private readonly IRepository<ArticleAuthor> _articleAuthorRepo;
        private readonly IActionService _actionService;
        public ArticleService(IRepository<Article> articleRepo,  IRepository<ArticleAuthor> articleAuthorRepo, IActionService actionService)
        {
            _articleRepo = articleRepo;
            _articleAuthorRepo = articleAuthorRepo;
            _actionService = actionService;
        }
        public List<Article> GetAllArticles()
        {
            return _articleRepo.GetAll().Where(p => p.isDeleted == false).ToList();
        }

        public List<Article> GetAllDeletedArticles()
        {
            return _articleRepo.GetAll().Where(p => p.isDeleted == true).ToList();
        }

        public List<Article> GetArticlesByTopicID(int topicID)
        {
            return _articleRepo.GetAll().Where(p => p.isDeleted == false && p.topicID == topicID).ToList();
        }
        public Article GetArticleByID(int articleID)
        {
            return _articleRepo.GetById(articleID);
        }

        public void AddArticle(int? topicID, Article article, List<int> reqListAuthorIds, int accountID)
        {
            if(topicID != 0)
                article.topicID = topicID;
            article.timeCreate = DateTime.Now;
            _articleRepo.Insert(article);
            _articleRepo.Save();

            foreach(int id in reqListAuthorIds)
            { 
                _articleAuthorRepo.Insert(new ArticleAuthor()
                {
                    article = article,
                    authorID = id
                });
            }

            var action = new PBL3.Models.Action()
            {
                accountID = accountID,
                objectID = article.ID,
                dateTime = DateTime.Now,
                action = "Tạo mới",
                typeObject = Convert.ToInt32(TypeObject.Article)
            };

            _actionService.AddAction(action);
        }
        public void UpdateArticle(int id, Article reqArticle, int? topicID, List<int> reqListAuthorIds, int accountID)
        {
            var article = this.GetArticleByID(id);
            var action = new PBL3.Models.Action()
            {
                accountID = accountID,
                objectID = (int)id,
                dateTime = DateTime.Now,
                action = "Sửa ",
                typeObject = Convert.ToInt32(TypeObject.Article)
            };

            if(article.content != reqArticle.content)
                action.action += "nội dung bài viết, ";
                
            if(article.title != reqArticle.title)
                action.action += "tên bài viết, ";

            if(topicID != 0 && article.topicID != topicID)
                action.action += "chủ đề, ";

            if(article.IsPublic != reqArticle.IsPublic)
                action.action += "trạng thái, ";

            var listArticleAuthors = _articleAuthorRepo.GetAll().Where(p => p.articleID == (int)id && p.isDeleted == false);

            if(Utility.DifferentList(reqListAuthorIds, listArticleAuthors.Select(p => p.authorID).ToList()))
                action.action += "tác giả, ";

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

            article.content = reqArticle.content;
            article.title = reqArticle.title;
            article.topicID = topicID;
            article.IsPublic = reqArticle.IsPublic;

            action.action.Substring(0, action.action.Length - 2);
            _actionService.AddAction(action);

            _articleRepo.Update(article);
            _articleRepo.Save();
        }
        public void UpdateArticle(Article article)
        {
            _articleRepo.Update(article);
            _articleRepo.Save();
        }
        public void ChangeIsDeletedArticle(int articleID, int accountID)
        {
            var article = GetArticleByID(articleID);

            var action = new PBL3.Models.Action()
            {
                accountID = (int)accountID,
                objectID = articleID,
                dateTime = DateTime.Now,
                typeObject = Convert.ToInt32(TypeObject.Problem)
            };

            if(article.isDeleted == false)
                action.action = "Xóa bài tập";
            else
                action.action = "Khôi phục bài tập";
            
            _actionService.AddAction(action);
            article.isDeleted = !article.isDeleted;
            _articleRepo.Save();
        }
    }
}