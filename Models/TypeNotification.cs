using System;
using System.Collections.Generic;

namespace PBL3.Models
{
    public class TypeNotification
    {
        public TypeNotification()
        {
            notifications = new List<Notification>();
        }
        public int ID{get; set;}
        public string name{get; set;}
        public List<Notification> notifications{get; set;}
    }
}