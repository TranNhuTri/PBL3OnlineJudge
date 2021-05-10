using System;
using System.Collections.Generic;

namespace PBL3.Models
{
    public class SearchForm
    {
        public string ProblemName{get; set;}
        public bool HideSolvedProblem{get; set;}
        public string ProblemCategory{get; set;}
        public int? MinDiff{get; set;}
        public int? MaxDiff{get; set;}
    }
}