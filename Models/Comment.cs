using System;
using System.Collections.Generic;

namespace PBL3.Models
{
    public class Comment
    {
        public Comment()
        {
            child = new List<Comment>();
        }
        public int ID{get; set;}
        public string content{get; set;}
        public DateTime timeCreate{get; set;}
        public int level{get; set;}
        public bool isHidden{get; set;}
        public int accountID{get; set;}
        public Account account{get; set;}
        public int? rootCommentID{get; set;}
        public Comment rootComment{get; set;}
        public int postID{get; set;}
        public bool isDeleted{get; set;}
        public List<Comment> child{get; set;}
        public List<Like> likes{get; set;}
    } 
}