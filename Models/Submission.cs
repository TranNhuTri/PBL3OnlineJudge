using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3.Models
{
    public class Submission
    {
        public Submission()
        {
            submissionResults = new List<SubmissionResult>();
        }
        public int ID{get; set;}
        public int accountID {get; set;}
        public Account account{get; set;}
        public int problemID{get; set;}
        public Problem problem{get; set;}
        public DateTime timeCreate{get; set;}
        public string code{get; set;}
        public string language{get; set;}
        public string status {get; set;}
        public float time{get; set;}
        public float memory{get; set;}
        public bool isDeleted{get; set;}
        public List<SubmissionResult> submissionResults {get; set;}
    }
}