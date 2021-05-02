using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3.Models
{
    public class Submission
    {
        public int ID{get; set;}
        public int AccountID{get; set;}
        public Account Account{get; set;}
        public string ProblemID{get; set;}
        public Problem Problem{get; set;}
        public DateTime DateSubmit{get; set;}
        public string Code{get; set;}
        public string Language{get; set;}
        public string Status {get; set;}
        public float Time{get; set;}
    }
}