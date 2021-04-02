using System;

namespace PBL3.Models
{
    public class Problem
    {
        public string ID{get; set;}
        public string Title{get; set;}
        public string Content{get; set;}
        public bool Status{get; set;}
        public int Difficulty{get; set;}
        public float SuccessRate{get; set;}
    }
}