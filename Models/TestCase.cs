using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3.Models
{
    public class TestCase
    {
        public TestCase()
        {
            SubmitResults = new List<SubmitResult>();
        }
        public int ID{get; set;}
        public string Input{get; set;}
        public string Output{get; set;}
        public string ProblemID{get; set;}
        public virtual Problem Problem{get; set;}
        public virtual List<SubmitResult> SubmitResults {get; set;}
    } 
}