using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Bạn cần điền tên đăng nhập")]
        public string UserName{get; set;}
        [Required(ErrorMessage = "Bạn cần điền mật khẩu")]
        [StringLength(int.MaxValue, MinimumLength = 6, ErrorMessage = "Mật khẩu ít nhất 6 kí tự")]
        public string PassWord{get; set;}
    }
}