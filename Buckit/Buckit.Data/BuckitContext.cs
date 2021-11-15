using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Buckit.Model;

namespace Buckit.Data
{
    public class BuckitContext : IdentityDbContext<BuckitUser, IdentityRole, string>
    {
        public BuckitContext()
        {
        }
        public BuckitContext(DbContextOptions options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
			builder.Entity<Account>().HasKey(a => a.AccountId);
			builder.Entity<Bucket>().HasKey(b => b.BucketId);
			builder.Entity<BuckitUser>().HasKey(b => b.UserId);
			builder.Entity<Transaction>().HasKey(t => t.TransactionId);

			//builder.Entity<Ride>().HasKey(r => r.RideId);
			//builder.Entity<Ride>()
			//	.HasOne(i => i.Driver)
			//	.WithMany(i => i.Rides)
			//	.HasForeignKey(i => i.DriverId)
			//	.OnDelete(DeleteBehavior.Restrict);

			//builder.Entity<Ride>()
			//  .HasOne(i => i.Vehicle)
			//  .WithMany(i => i.Rides)
			//  .HasForeignKey(i => i.VehicleId)
			//  .OnDelete(DeleteBehavior.Restrict);

			//builder.Entity<Vehicle>()
			//   .HasOne(p => p.Driver)
			//   .WithOne(i => i.Vehicle)
			//   .HasForeignKey<Driver>(b => b.VehicleId);


			base.OnModelCreating(builder);
		}
    }
}
