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
        public string accountName{get; set;}
        [Required(ErrorMessage = "Bạn cần điền mật khẩu")]
        [StringLength(int.MaxValue, MinimumLength = 6, ErrorMessage = "Mật khẩu ít nhất 6 kí tự")]
        public string passWord{get; set;}
        [Required(ErrorMessage = "Bạn cần điền Email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string email{get; set;}
        [Required(ErrorMessage = "Bạn cần điền họ")]
        public string lastName{get; set;}
        [Required(ErrorMessage = "Bạn cần điền tên")]
        public string firstName{get; set;}
        public bool isActived{get; set;}
        public string token{get; set;}
        // 1: Admin 2: Author 3: User
        public int typeAccount{get; set;}
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