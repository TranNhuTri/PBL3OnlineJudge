using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
    public class Article
    {
        public Article()
        {
            articleAuthors = new List<ArticleAuthor>();
        }
        public int ID{get; set;}
        [Required(ErrorMessage = "Bạn cần điền tên bài viết")]
        [StringLength(300)]
        public string title{get; set;}
        public string content{get; set;}
        public DateTime timeCreate{get; set;}
        public int? topicID{get; set;}
        public Topic topic{get; set;}
        public bool IsPublic {get; set;}
        public bool isDeleted{get; set;}
        public List<ArticleAuthor> articleAuthors{get; set;}
    }
}