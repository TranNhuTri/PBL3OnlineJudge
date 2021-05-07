using System;
using System.Collections.Generic;

namespace PBL3.Models
{
    public class Account
    {
        public Account()
        {
            Submissions = new List<Submission>();
        }
        public int ID{get; set;}
        public string AccountName{get; set;}
        public string PassWord{get; set;}
        public string Email{get; set;}
        public bool IsActived{get; set;}
        public string Token{get; set;}
        // 1: Admin 2: Author 3: User
        public int TypeAccount{get; set;}
        public DateTime DateCreate{get; set;}
        public virtual List<Submission> Submissions{get; set;}
    }
}