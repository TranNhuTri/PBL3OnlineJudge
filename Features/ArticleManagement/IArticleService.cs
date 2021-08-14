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
        void AddArticle(int? topicID, Article article, List<int> reqListAuthorIds, int accountID);
        void UpdateArticle(int id, Article reqArticle, int? topicID, List<int> reqListAuthorIds, int accountID);
        void UpdateArticle(Article article);
        void ChangeIsDeletedArticle(int articleID, int accountID);
    }
}