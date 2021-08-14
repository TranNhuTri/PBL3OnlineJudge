using System.Collections.Generic;
using PBL3.Models;

namespace PBL3.Features.ArticleManagement
{
    public interface IArticleService
    {
        List<Article> GetAllArticles();
        List<Article> GetAllDeletedArticles();
        Article GetArticleByID(int articleID);
        List<Article> GetArticlesByTopicID(int topicID);
        void AddArticle(Article article);
        void UpdateArticle(Article article);
        void DeleteArticle(int articleID);
        void ChangeIsDeletedArticle(int articleID);
    }
}