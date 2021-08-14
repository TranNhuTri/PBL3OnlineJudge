using System.Collections.Generic;
using System.Linq;
using PBL3.Models;
using PBL3.Repositories;

namespace PBL3.Features.ArticleManagement
{
    public class ArticleService: IArticleService
    {
        private readonly IRepository<Article> _articleRepo;
        public ArticleService(IRepository<Article> articleRepo)
        {
            _articleRepo = articleRepo;
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

        public void AddArticle(Article article)
        {
            _articleRepo.Insert(article);
            _articleRepo.Save();
        }
        public void UpdateArticle(Article article)
        {
            _articleRepo.Update(article);
            _articleRepo.Save();
        }
        public void DeleteArticle(int articleID)
        {
            _articleRepo.Delete(articleID);
            _articleRepo.Save();
        }
        public void ChangeIsDeletedArticle(int articleID)
        {
            var article = GetArticleByID(articleID);
            article.isDeleted = !article.isDeleted;
            _articleRepo.Save();
        }
    }
}