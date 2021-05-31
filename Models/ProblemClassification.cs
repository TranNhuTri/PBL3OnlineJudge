using System;
using System.Collections.Generic;

namespace PBL3.Models
{
    public class ProblemClassification
    {
        public int ID{get; set;}
        public int problemID{get; set;}
        public Problem problem{get; set;}
        public int categoryID{get; set;}
        public Category category{get; set;}
        public bool isDeleted{get; set;}
    }
}