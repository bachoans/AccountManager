using AccountManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountSubscription> AccountSubscriptions { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<AccountSubscriptionStatus> AccountSubscriptionStatuses { get; set; }
        public DbSet<AccountChangesLog> AccountChangesLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasOne(a => a.AccountSubscriptions)
                .WithOne(s => s.Account)
                .HasForeignKey<AccountSubscription>(s => s.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AccountSubscription>()
                .HasOne(s => s.Subscription)
                .WithMany()
                .HasForeignKey(s => s.SubscriptionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AccountSubscription>()
                .HasOne(s => s.AccountSubscriptionStatus)
                .WithMany()
                .HasForeignKey(s => s.SubscriptionStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AccountChangesLog>()
                .HasOne(log => log.Account)
                .WithMany()
                .HasForeignKey(log => log.AccountId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
