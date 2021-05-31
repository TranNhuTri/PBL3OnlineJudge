using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
    public class ArticleAuthor
    {
        public int ID {get; set;}
        public int articleID{get; set;}
        public Article article{get; set;}
        public int authorID{get; set;}
        public Account author{get; set;}
        public bool isDeleted{get; set;}
    }
}