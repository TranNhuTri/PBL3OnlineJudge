using Microsoft.EntityFrameworkCore;
using PBL3.Models;
using System.Collections.Generic;
using PBL3.General;

namespace PBL3.Data
{
    public class PBL3Context : DbContext
    {
        public PBL3Context (DbContextOptions<PBL3Context> options = null)
            : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles{get; set;}
        public DbSet<Comment> Comments{get; set;}
        public DbSet<TestCase> TestCases{get; set;}
        public DbSet<Notification> Notifications{get; set;}
        public DbSet<Submission> Submissions {get; set;}
        public DbSet<SubmissionResult> SubmissionResults {get; set;}
        public DbSet<Category> Categories{get; set;}
        public DbSet<Article> Articles{get; set;}
        public DbSet<Topic> Topics{get; set;}
        public DbSet<ProblemAuthor> ProblemAuthors{get; set;}
        public DbSet<ProblemClassification> ProblemClassifications{get; set;}
        public DbSet<ArticleAuthor> ArticleAuthors{get; set;}
        public DbSet<Like> Likes{get; set;}
        public DbSet<Action> Actions{get; set;}
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var listRole = new List<Role>();

            listRole.Add(new Role()
            {
                ID = 1,
                name = "Admin"
            });

            listRole.Add(new Role()
            {
                ID = 2,
                name = "Author"
            });

            listRole.Add(new Role()
            {
                ID = 3,
                name = "User"
            });

            builder.Entity<Role>().HasData(listRole);

            builder.Entity<Account>().HasData(
                new Account()
                {
                    ID = 1,
                    accountName = "Admin",
                    passWord = Utility.CreateMD5("123456"),
                    email = "trannhutri0703@gmail.com",
                    firstName = "",
                    lastName = "Admin",
                    roleID = 1,
                    isActived = true,
                    timeCreate = System.DateTime.Now
                }
            );
        }
    }
}