using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PBL3.Models
{
    public class SubmissionResult
    {
        public int ID{get; set;}
        public int submissionID{get; set;}
        public Submission submission{get; set;}
        public int? testCaseID{get; set;}
        public TestCase testCase{get; set;}
        public string result{get; set;}
        [StringLength(100)]
        public string status{get; set;}
        public float excuteTime{get; set;}
        public float memory{get; set;}
        public bool isDeleted{get; set;}
    }
}