using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace PBL3.Models
{
    public class SubmitResult
    {
        public int ID{get; set;}
        public int SubmissionID{get; set;}
        public virtual Submission Submission{get; set;}
        public int TestCaseID{get; set;}
        public virtual TestCase TestCase{get; set;}
        public string Result{get; set;}
    }
}