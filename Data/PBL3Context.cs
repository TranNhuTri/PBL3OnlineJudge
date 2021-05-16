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
        public DbSet<Problem> Problem { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<TestCase> TestCase{get; set;}
        public DbSet<Submission> Submission {get; set;}
        public DbSet<SubmissionResult> SubmissionResult {get; set;}
        public DbSet<Category> Category{get; set;}
        public DbSet<Article> Article{get; set;}
        public DbSet<ProblemAuthor> ProblemAuthor{get; set;}
        public DbSet<ProblemCategory> ProblemCategory{get; set;}
        public DbSet<ArticleAuthor> ArticleAuthor{get; set;}
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<ProblemAuthor>()
                .HasKey(x => new {x.ProblemID, x.AuthorID});
            modelBuilder.Entity<ArticleAuthor>()
                .HasKey(x => new {x.ArticleID, x.AuthorID});
            modelBuilder.Entity<ProblemCategory>()
                .HasKey(x => new {x.ProblemID, x.CategoryID});
        }
    }
}