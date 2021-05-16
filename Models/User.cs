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
            ProblemAuthors = new List<ProblemAuthor>();
            ArticleAuthors = new List<ArticleAuthor>();
        }
        public int ID{get; set;}
        [Required(ErrorMessage = "Bạn cần điền tên đăng nhập")]
        public string UserName{get; set;}
        [Required(ErrorMessage = "Bạn cần điền mật khẩu")]
        [StringLength(int.MaxValue, MinimumLength = 6, ErrorMessage = "Mật khẩu ít nhất 6 kí tự")]
        public string PassWord{get; set;}
        [Required(ErrorMessage = "Bạn cần điền Email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email{get; set;}
        public bool Actived{get; set;}
        public string Token{get; set;}
        // 1: Admin 2: Author 3: User
        public int TypeAccount{get; set;}
        public DateTime TimeCreate{get; set;}
        public List<Submission> Submissions{get; set;}
        public List<ProblemAuthor> ProblemAuthors{get; set;}
        public List<ArticleAuthor> ArticleAuthors{get; set;}
    }
}