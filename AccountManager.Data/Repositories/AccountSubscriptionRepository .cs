using AccountManager.Data.Entities;
using AccountManager.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Data.Repositories
{
    public class AccountSubscriptionRepository : IAccountSubscriptionRepository
    {
        private readonly AppDbContext _context;

        public AccountSubscriptionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AccountSubscription?> GetByAccountIdAsync(int accountId)
        {
            return await _context.AccountSubscriptions
                .Include(s => s.Subscription)
                .Include(s => s.AccountSubscriptionStatus)
                .FirstOrDefaultAsync(s => s.AccountId == accountId);
        }

        public async Task AddOrUpdateAsync(AccountSubscription subscription)
        {
            var existing = await GetByAccountIdAsync(subscription.AccountId);
            if (existing == null)
                _context.AccountSubscriptions.Add(subscription);
            else
                _context.AccountSubscriptions.Update(subscription);

            await _context.SaveChangesAsync();
        }
    }
}
