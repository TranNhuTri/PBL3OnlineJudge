using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3.Models
{
    public class ProblemAuthor
    {
        public int ID {get; set;}
        public int problemID{get; set;}
        public Problem problem{get; set;}
        public int authorID{get; set;}
        public Account author{get; set;}
        public bool isDeleted{get; set;}
    }
}