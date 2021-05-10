using System;
using System.Collections.Generic;

namespace PBL3.Models
{
    public class Category
    {
        public Category()
        {
            ProblemCategories = new List<ProblemCategory>();
        }
        public int ID{get; set;}
        public string Name{get; set;}
        public List<ProblemCategory> ProblemCategories{get; set;}
    }
}