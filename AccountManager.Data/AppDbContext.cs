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

        /// <summary>
        /// Configures the entity relationships and foreign key constraints between the core entities.
        /// This ensures correct behavior for navigation properties and cascade deletes.
        /// Seeds initial data into the Subscriptions and AccountSubscriptionStatuses tables.
        /// The data will be inserted automatically during the first database migration.
        /// </summary>
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

            // Seed Subscriptions
            modelBuilder.Entity<Subscription>().HasData(
                new Subscription
                {
                    SubscriptionId = 1,
                    Description = "Basic Plan",
                    IsDefault = true,
                    IsActive = true,
                    AvailableYearly = true,
                    Is2FAAllowed = false,
                    IsIPFilterAllowed = false,
                    IsSessionTimeoutAllowed = false
                },
                new Subscription
                {
                    SubscriptionId = 2,
                    Description = "Pro Plan",
                    IsDefault = false,
                    IsActive = true,
                    AvailableYearly = true,
                    Is2FAAllowed = true,
                    IsIPFilterAllowed = true,
                    IsSessionTimeoutAllowed = false
                },
                new Subscription
                {
                    SubscriptionId = 3,
                    Description = "Enterprise Plan",
                    IsDefault = false,
                    IsActive = true,
                    AvailableYearly = true,
                    Is2FAAllowed = true,
                    IsIPFilterAllowed = true,
                    IsSessionTimeoutAllowed = true
                }
            );

            // Seed Subscription Statuses
            modelBuilder.Entity<AccountSubscriptionStatus>().HasData(
                new AccountSubscriptionStatus
                {
                    SubscriptionStatusId = 1,
                    Description = "Active",
                    IsDefault = true,
                    IsActive = true,
                    IsCancelled = false,
                    IsDeleted = false
                },
                new AccountSubscriptionStatus
                {
                    SubscriptionStatusId = 2,
                    Description = "Paused",
                    IsDefault = false,
                    IsActive = true,
                    IsCancelled = false,
                    IsDeleted = false
                },
                new AccountSubscriptionStatus
                {
                    SubscriptionStatusId = 3,
                    Description = "Cancelled",
                    IsDefault = false,
                    IsActive = false,
                    IsCancelled = true,
                    IsDeleted = false
                }
            );
        }
    }
}
