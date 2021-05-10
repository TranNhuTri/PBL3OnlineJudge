using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3.Models
{
    public class Submission
    {
        public Submission()
        {
            SubmissionResults = new List<SubmissionResult>();
        }
        public int ID{get; set;}
        public int UserID {get; set;}
        public User User{get; set;}
        public string ProblemID{get; set;}
        public Problem Problem{get; set;}
        public DateTime TimeCreate{get; set;}
        public string Code{get; set;}
        public string Language{get; set;}
        public string Status {get; set;}
        public float Time{get; set;}
        public List<SubmissionResult> SubmissionResults {get; set;}
    }
}