using System.ComponentModel.DataAnnotations.Schema;

namespace PBL3.Models
{
    public class TestCase
    {
        public int ID{get; set;}
        public string Input{get; set;}
        public string Output{get; set;}
        public string ProblemID{get; set;}
        public virtual Problem Problem{get; set;}
    } 
}