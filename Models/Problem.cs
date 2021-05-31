using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
    public class Problem
    {
        public Problem()
        {
            submissions = new List<Submission>();
            testCases = new List<TestCase>();
            problemClassifications = new List<ProblemClassification>();
            problemAuthors = new List<ProblemAuthor>();
        }
        public int ID{get; set;}
        [Required(ErrorMessage = "Bạn cần điền mã bài")]
        public string code{get; set;}
        [Required(ErrorMessage = "Bạn cần điền tên bài")]
        public string title{get; set;}
        public string content{get; set;}
        [Required(ErrorMessage = "Bạn cần điền độ khó")]
        public int? difficulty{get; set;}
        public bool isPublic{get; set;}
        public DateTime timeCreate{get; set;}
        [Required(ErrorMessage = "Bạn cần điền thời gian giới hạn")]
        public float? timeLimit{get; set;}
        [Required(ErrorMessage = "Bạn cần điền giới hạn bộ nhớ")]
        public int? memoryLimit{get; set;}
        public bool isDeleted{get; set;}
        public List<Submission> submissions{get; set;}
        public List<TestCase> testCases{get; set;}
        public List<ProblemClassification> problemClassifications{get; set;}
        public List<ProblemAuthor> problemAuthors{get; set;}
    }
}