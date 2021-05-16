using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
    public class Category
    {
        public Category()
        {
            ProblemCategories = new List<ProblemCategory>();
        }
        public int ID{get; set;}
        [Required(ErrorMessage = "Bạn cần nhập tên dạng bài")]
        public string Name{get; set;}
        public List<ProblemCategory> ProblemCategories{get; set;}
    }
}