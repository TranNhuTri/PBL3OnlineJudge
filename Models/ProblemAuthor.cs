using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3.Models
{
    public class ProblemAuthor
    {
        public string ProblemID{get; set;}
        public Problem Problem{get; set;}
        public int AuthorID{get; set;}
        public User Author{get; set;}
    }
}