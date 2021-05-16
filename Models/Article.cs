using System;
using System.Collections.Generic;

namespace PBL3.Models
{
    public class Article
    {
        public Article()
        {
            ArticleAuthors = new List<ArticleAuthor>();
        }
        public int ID{get; set;}
        public string Title{get; set;}
        public string Content{get; set;}
        public DateTime TimeCreate{get; set;}
        public bool Public {get; set;}
        public List<ArticleAuthor> ArticleAuthors{get; set;}
    }
}