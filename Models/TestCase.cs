using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3.Models
{
    public class TestCase
    {
        public TestCase()
        {
            submitResults = new List<SubmissionResult>();
        }
        public int ID{get; set;}
        public string input{get; set;}
        public string output{get; set;}
        public int problemID{get; set;}
        public Problem problem{get; set;}
        public bool isDeleted{get; set;}
        public List<SubmissionResult> submitResults {get; set;}
    } 
}