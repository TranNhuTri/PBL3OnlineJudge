using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBL3.DTO
{
    public class EditAccount
    {
        public int ID{get; set;}
        [Required(ErrorMessage = "Bạn cần điền tên đăng nhập")]
        public string accountName{get; set;}
        [Required(ErrorMessage = "Bạn cần điền họ")]
        public string lastName{get; set;}
        public string firstName{get; set;}
        
        [Required(ErrorMessage = "Bạn cần điền Email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string email{get; set;}
        public bool isActived{get; set;}
        public int roleID{get; set;}
        public DateTime timeCreate{get; set;}
    }
}