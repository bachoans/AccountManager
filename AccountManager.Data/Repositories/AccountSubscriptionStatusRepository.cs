using AccountManager.Data.Entities;
using AccountManager.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.Data.Repositories
{
    public class AccountSubscriptionStatusRepository : IAccountSubscriptionStatusRepository
    {
        private readonly AppDbContext _context;

        public AccountSubscriptionStatusRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AccountSubscriptionStatus>> GetAllAsync()
        {
            return await _context.AccountSubscriptionStatuses
                                 .AsNoTracking()
                                 .Where(s => s.IsActive && !s.IsDeleted)
                                 .ToListAsync();
        }
    }
}