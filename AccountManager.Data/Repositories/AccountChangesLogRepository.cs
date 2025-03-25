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
    public class AccountChangesLogRepository : IAccountChangesLogRepository
    {
        private readonly AppDbContext _context;

        public AccountChangesLogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task LogChangeAsync(AccountChangesLog log)
        {
            _context.AccountChangesLogs.Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AccountChangesLog>> GetLogsByAccountIdAsync(int accountId)
        {
            return await _context.AccountChangesLogs
                .Where(l => l.AccountId == accountId)
                .OrderByDescending(l => l.Timestamp)
                .ToListAsync();
        }
    }
}
