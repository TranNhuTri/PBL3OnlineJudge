using System;
using System.Collections.Generic;

namespace PBL3.Models
{
    public class Article
    {
        public int ID{get; set;}
        public string Title{get; set;}
        public string Content{get; set;}
        public DateTime TimeCreate{get; set;}
        public bool Public {get; set;}
        public int UserID{get; set;}
        public User User{get; set;}
    }
}