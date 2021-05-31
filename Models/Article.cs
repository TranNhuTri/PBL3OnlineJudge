using System;
using System.Collections.Generic;

namespace PBL3.Models
{
    public class Article
    {
        public Article()
        {
            articleAuthors = new List<ArticleAuthor>();
        }
        public int ID{get; set;}
        public string title{get; set;}
        public string content{get; set;}
        public DateTime timeCreate{get; set;}
        public bool IsPublic {get; set;}
        public bool isDeleted{get; set;}
        public List<ArticleAuthor> articleAuthors{get; set;}
    }
}