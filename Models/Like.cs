using System;
using System.Collections.Generic;

namespace PBL3.Models
{
    public class Like
    {
        public int ID{get; set;}
        public int accountID{get; set;}
        public Account account{get; set;}
        public int? commentID {get; set;}
        public Comment comment{get; set;}
        public bool status{get; set;}
    } 
}