using System;
using System.Collections.Generic;

namespace PBL3.Models
{
    public class Problem
    {
        public Problem()
        {
            Submissions = new List<Submission>();
            TestCases = new List<TestCase>();
            ProblemCategories = new List<ProblemCategory>();
        }
        public string ID{get; set;}
        public string Title{get; set;}
        public string Content{get; set;}
        public int Difficulty{get; set;}
        public bool Public{get; set;}
        public DateTime TimeCreate{get; set;}
        public float TimeLimit{get; set;}
        public int MemoryLimit{get; set;}
        public int UserID{get; set;}
        public User User{get; set;}
        public List<Submission> Submissions{get; set;}
        public List<TestCase> TestCases{get; set;}
        public List<ProblemCategory> ProblemCategories{get; set;}
    }
}