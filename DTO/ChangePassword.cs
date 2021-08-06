using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBL3.DTO
{
    public class ChangePassword
    {
        [Required(ErrorMessage = "Bạn cần nhập mật khẩu cũ")]
        public string oldPassword{get; set;}
        [Required(ErrorMessage = "Bạn cần nhập mật khẩu mới")]
        public string newPassword{get; set;}
        [Required(ErrorMessage = "Bạn cần nhập xác nhận mật khẩu mới")]
        public string confirmPassword{get; set;}
    }
}