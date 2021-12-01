using Buckit.Data;
using Buckit.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BuckitWeb
{
    public class BuckitContext : DbContext
    {
        public BuckitContext (DbContextOptions<buckitdbContext> options)
            : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountTransaction> AccountTransactions { get; set; }
        public DbSet<Bucket> Buckets { get; set; }
        public DbSet<BucketTransaction> BucketTransactions { get; set; }    
        public DbSet<BuckitUser> BuckitUsers { get; set;}
    }
}
