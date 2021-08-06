using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
    public class Category
    {
        public Category()
        {
            problemClassifications = new List<ProblemClassification>();
        }
        public int ID{get; set;}
        [Required(ErrorMessage = "Bạn cần nhập tên dạng bài")]
        [StringLength(300)]
        public string name{get; set;}
        public bool isDeleted{get; set;}
        public List<ProblemClassification> problemClassifications{get; set;}
    }
}