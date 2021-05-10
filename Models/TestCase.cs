using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3.Models
{
    public class TestCase
    {
        public TestCase()
        {
            SubmitResults = new List<SubmissionResult>();
        }
        public int ID{get; set;}
        public string Input{get; set;}
        public string Output{get; set;}
        public string ProblemID{get; set;}
        public Problem Problem{get; set;}
        public List<SubmissionResult> SubmitResults {get; set;}
    } 
}