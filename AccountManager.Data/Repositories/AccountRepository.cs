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
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;

        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Account>> GetAllAsync() =>
            await _context.Accounts.ToListAsync();

        public async Task<Account?> GetByIdAsync(int id) =>
            await _context.Accounts.FindAsync(id);

        public async Task<Account?> GetByTokenAsync(string token) =>
            await _context.Accounts.FirstOrDefaultAsync(a => a.Token == token);

        public async Task<List<Account>> SearchByCompanyNameAsync(string name) =>
            await _context.Accounts
                .Where(a => a.CompanyName.Contains(name))
                .ToListAsync();

        public async Task AddAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Account account)
        {
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
        }
    }
}
