using Microsoft.EntityFrameworkCore;
using AccountManager.Data.Entities;
using AccountManager.Data.Interfaces;
using AccountManager.Data;

public class AccountChangesLogRepository : IAccountChangesLogRepository
{
    private readonly AppDbContext _context;

    public AccountChangesLogRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<AccountChangesLog>> GetLogsByAccountIdAsync(int accountId)
    {
        return _context.AccountChangesLogs
                       .Where(x => x.AccountId == accountId)
                       .OrderByDescending(x => x.Timestamp)
                       .ToListAsync();
    }

    public async Task LogChangeAsync(AccountChangesLog log)
    {
        await _context.AccountChangesLogs.AddAsync(log);
        await _context.SaveChangesAsync();
    }
}
