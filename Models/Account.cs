using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
    public class Account
    {
        public Account()
        {
            submissions = new List<Submission>();
            problemAuthors = new List<ProblemAuthor>();
            articleAuthors = new List<ArticleAuthor>();
            comments = new List<Comment>();
        }
        public int ID{get; set;}
        [Required(ErrorMessage = "Bạn cần điền tên đăng nhập")]
        [StringLength(50)]
        public string accountName{get; set;}
        [Required(ErrorMessage = "Bạn cần điền mật khẩu")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Mật khẩu ít nhất 6 kí tự")]
        public string passWord{get; set;}
        [Required(ErrorMessage = "Bạn cần điền Email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string email{get; set;}
        [Required(ErrorMessage = "Bạn cần điền họ")]
        [StringLength(200)]
        public string lastName{get; set;}
        [Required(ErrorMessage = "Bạn cần điền tên")]
        [StringLength(200)]
        public string firstName{get; set;}
        public string avar{get; set;}
        public bool isActived{get; set;}
        public string token{get; set;}
        // 1: Admin 2: Author 3: User
        public int roleID{get; set;}
        public Role role{get; set;}
        public bool isDeleted{get; set;}
        public DateTime timeCreate{get; set;}
        public List<Submission> submissions{get; set;}
        public List<ProblemAuthor> problemAuthors{get; set;}
        public List<ArticleAuthor> articleAuthors{get; set;}
        public List<Comment> comments{get; set;}
        public List<Notification> notifications{get; set;}
        public List<Like> likes{get; set;}
    }
}