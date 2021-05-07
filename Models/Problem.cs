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
        }
        public string ID{get; set;}
        public string Title{get; set;}
        public string Content{get; set;}
        public bool Status{get; set;}
        public int Difficulty{get; set;}
        public float SuccessRate{get; set;}
        public virtual List<Submission> Submissions{get; set;}
        public virtual List<TestCase> TestCases{get; set;}
    }
}