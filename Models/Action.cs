using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
    public class Action
    {
        public int ID{get; set;}
        public int accountID{get; set;}
        public Account account{get; set;}
        public int objectID{get; set;}
        public string action{get; set;}
        public DateTime dateTime{get; set;}
        public int typeObject{get; set;}
    }
}