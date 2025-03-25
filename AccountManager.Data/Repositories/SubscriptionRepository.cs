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
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly AppDbContext _context;

        public SubscriptionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Subscription>> GetAllAsync() =>
            await _context.Subscriptions.ToListAsync();

        public async Task<Subscription?> GetByIdAsync(int id) =>
            await _context.Subscriptions.FindAsync(id);
    }
}
