using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PBL3.Models
{
    public class Role
    {
        public int ID{get; set;}
        [StringLength(100)]
        public string name{get; set;}
        public List<Account> accounts{get; set;}
    } 
}