using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PBL3.Models
{
    public class Role
    {
        public int ID{get; set;}
        public string name{get; set;}
        public List<Account> accounts{get; set;}
    } 
}