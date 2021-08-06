using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
    public class Topic
    {
        public Topic()
        {
            articles = new List<ProblemClassification>();
        }
        public int ID{get; set;}
        [Required(ErrorMessage = "Bạn cần nhập tên chủ đề")]
        [StringLength(300)]
        public string name{get; set;}
        public string describeImage{get; set;}
        public bool isDeleted{get; set;}
        public List<ProblemClassification> articles{get; set;}
    }
}