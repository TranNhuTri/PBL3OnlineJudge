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
    }
}