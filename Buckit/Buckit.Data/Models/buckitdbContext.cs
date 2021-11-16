using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Buckit.Data.Models
{
    public partial class buckitdbContext : DbContext
    {
        public buckitdbContext()
        {
        }

        public buckitdbContext(DbContextOptions<buckitdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AccountTransaction> AccountTransactions { get; set; } = null!;
        public virtual DbSet<Bucket> Buckets { get; set; } = null!;
        public virtual DbSet<BucketTransaction> BucketTransactions { get; set; } = null!;
        public virtual DbSet<BuckitUser> BuckitUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=bucket-db-server.postgres.database.azure.com;Database=buckitdb;Username=bucketdbserveradmin@bucket-db-server;Password=Hahs1357");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.AccountNumber).HasColumnName("account_number");

                entity.Property(e => e.BuckitUserId).HasColumnName("buckit_user_id");

                entity.Property(e => e.CreateDatetime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CurrentBalance)
                    .HasPrecision(12, 2)
                    .HasColumnName("current_balance");

                entity.Property(e => e.DeleteFlag)
                    .HasColumnName("delete_flag")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.InstitutionName).HasColumnName("institution_name");

                entity.HasOne(d => d.BuckitUser)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.BuckitUserId)
                    .HasConstraintName("fk_buckit_user");
            });

            modelBuilder.Entity<AccountTransaction>(entity =>
            {
                entity.ToTable("account_transaction");

                entity.Property(e => e.AccountTransactionId)
                    .HasColumnName("account_transaction_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Amount)
                    .HasPrecision(12, 2)
                    .HasColumnName("amount");

                entity.Property(e => e.CreateDatetime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EventOccuredDatetime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("event_occured_datetime");

                entity.Property(e => e.InstituteTransactionId).HasColumnName("institute_transaction_id");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountTransactions)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("fk_account");
            });

            modelBuilder.Entity<Bucket>(entity =>
            {
                entity.ToTable("bucket");

                entity.Property(e => e.BucketId)
                    .HasColumnName("bucket_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Balance)
                    .HasPrecision(12, 2)
                    .HasColumnName("balance");

                entity.Property(e => e.CreateDatetime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeleteFlag)
                    .HasColumnName("delete_flag")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EndDate).HasColumnName("end_date");

                entity.Property(e => e.StartDate).HasColumnName("start_date");

                entity.Property(e => e.TargetAmount)
                    .HasPrecision(12, 2)
                    .HasColumnName("target_amount");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<BucketTransaction>(entity =>
            {
                entity.ToTable("bucket_transaction");

                entity.Property(e => e.BucketTransactionId)
                    .HasColumnName("bucket_transaction_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.BucketId).HasColumnName("bucket_id");

                entity.Property(e => e.CreateDatetime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.HasOne(d => d.Bucket)
                    .WithMany(p => p.BucketTransactions)
                    .HasForeignKey(d => d.BucketId)
                    .HasConstraintName("fk_bucket");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.BucketTransactions)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("fk_buckit_user");
            });

            modelBuilder.Entity<BuckitUser>(entity =>
            {
                entity.ToTable("buckit_user");

                entity.HasIndex(e => e.Username, "buckit_user_username_key")
                    .IsUnique();

                entity.Property(e => e.BuckitUserId)
                    .HasColumnName("buckit_user_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CreateDatetime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DeleteFlag)
                    .HasColumnName("delete_flag")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.FirstName).HasColumnName("first_name");

                entity.Property(e => e.LastName).HasColumnName("last_name");

                entity.Property(e => e.Username).HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
