using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
    public class User
    {
        public User()
        {
            Submissions = new List<Submission>();
            Problems = new List<Problem>();
            Articles = new List<Article>();
        }
        public int ID{get; set;}
        [Required(ErrorMessage = "Bạn cần điền tên đăng nhập")]
        public string UserName{get; set;}
        [Required(ErrorMessage = "Bạn cần điền mật khẩu")]
        public string PassWord{get; set;}
        [Required(ErrorMessage = "Bạn cần điền Email")]
        public string Email{get; set;}
        public bool Actived{get; set;}
        public string Token{get; set;}
        // 1: Admin 2: Author 3: User
        public int TypeAccount{get; set;}
        public DateTime TimeCreate{get; set;}
        public List<Submission> Submissions{get; set;}
        public List<Problem> Problems{get; set;}
        public List<Article> Articles{get; set;}
    }
}