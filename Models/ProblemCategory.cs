using System;
using System.Collections.Generic;

namespace PBL3.Models
{
    public class ProblemCategory
    {
        public int ID{get; set;}
        public int ProblemID{get; set;}
        public Problem Problem{get; set;}
        public int CategoryID{get; set;}
        public Category Category{get; set;}
    }
}