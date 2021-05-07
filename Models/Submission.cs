using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3.Models
{
    public class Submission
    {
        public Submission()
        {
            SubmitResults = new List<SubmitResult>();
        }
        public int ID{get; set;}
        public int AccountID {get; set;}
        public virtual Account Account{get; set;}
        public string ProblemID{get; set;}
        public virtual Problem Problem{get; set;}
        public DateTime DateSubmit{get; set;}
        public string Code{get; set;}
        public string Language{get; set;}
        public string Status {get; set;}
        public float Time{get; set;}
        public virtual List<SubmitResult> SubmitResults {get; set;}
    }
}