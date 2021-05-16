using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
    public class Problem
    {
        public Problem()
        {
            Submissions = new List<Submission>();
            TestCases = new List<TestCase>();
            ProblemCategories = new List<ProblemCategory>();
            ProblemAuthors = new List<ProblemAuthor>();
        }
        [Required(ErrorMessage = "Bạn cần điền mã bài")]
        public string ID{get; set;}
        [Required(ErrorMessage = "Bạn cần điền tên bài")]
        public string Title{get; set;}
        public string Content{get; set;}
        [Required(ErrorMessage = "Bạn cần điền độ khó")]
        public int? Difficulty{get; set;}
        public bool Public{get; set;}
        public DateTime TimeCreate{get; set;}
        [Required(ErrorMessage = "Bạn cần điền thời gian giới hạn")]
        public float? TimeLimit{get; set;}
        [Required(ErrorMessage = "Bạn cần điền giới hạn bộ nhớ")]
        public int? MemoryLimit{get; set;}
        public List<Submission> Submissions{get; set;}
        public List<TestCase> TestCases{get; set;}
        public List<ProblemCategory> ProblemCategories{get; set;}
        public List<ProblemAuthor> ProblemAuthors{get; set;}
    }
}