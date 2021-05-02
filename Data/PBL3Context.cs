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
        public DbSet<Account> Account { get; set; }
        public DbSet<TestCase> TestCase{get; set;}
        public DbSet<Submission> Submission {get; set;}
        public DbSet<SubmitResult> SubmitResult {get; set;}
    }
}