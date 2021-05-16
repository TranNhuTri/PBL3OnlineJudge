using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
    public class ArticleAuthor
    {
        public int ArticleID{get; set;}
        public Article Article{get; set;}
        public int AuthorID{get; set;}
        public User Author{get; set;}
    }
}