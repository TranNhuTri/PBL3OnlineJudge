using System.Collections.Generic;
using PBL3.Models;

namespace PBL3.Features.ArticleManagement
{
    public interface IArticleService
    {
        List<Article> GetAllArticles();
        Article GetArticleByID(int articleID);
        void AddArticle(Article article);
        void UpdateArticle(Article article);
        void DeleteArticle(int articleID);
    }
}