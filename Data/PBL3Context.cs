using Microsoft.EntityFrameworkCore;
using PBL3.Models;

namespace PBL3.Data
{
    public class PBL3Context : DbContext
    {
        public PBL3Context (DbContextOptions<PBL3Context> options)
            : base(options)
        {
        }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Comment> Comments{get; set;}
        public DbSet<TestCase> TestCases{get; set;}
        public DbSet<Notification> Notifications{get; set;}
        public DbSet<TypeNotification> TypeNotifications{get; set;}
        public DbSet<Submission> Submissions {get; set;}
        public DbSet<SubmissionResult> SubmissionResults {get; set;}
        public DbSet<Category> Categories{get; set;}
        public DbSet<Article> Articles{get; set;}
        public DbSet<ProblemAuthor> ProblemAuthors{get; set;}
        public DbSet<ProblemClassification> ProblemClassifications{get; set;}
        public DbSet<ArticleAuthor> ArticleAuthors{get; set;}
        public DbSet<Like> Likes{get; set;}
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}