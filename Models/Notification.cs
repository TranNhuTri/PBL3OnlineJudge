using System;
using System.Collections.Generic;

namespace PBL3.Models
{
    public class Notification
    {
        public int ID{get; set;}
        public string content{get; set;}
        public DateTime timeCreate{get; set;}
        public bool seen{get; set;}
        public int accountID{get; set;}
        public Account account{get; set;}
        public int objectID{get; set;}
        public bool isDeleted{get; set;}
        public int typeNotification{get; set;}
    } 
}