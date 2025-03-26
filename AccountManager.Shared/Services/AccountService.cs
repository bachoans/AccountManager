using AccountManager.Data.Entities;
using AccountManager.Data.Interfaces;
using AccountManager.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Shared.Services
{
    /// <summary>
    /// Handles all business logic related to accounts.
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repo;
        private readonly IAccountLogService _logService;

        public AccountService(IAccountRepository repo, IAccountLogService logService)
        {
            _repo = repo;
            _logService = logService;
        }

        /// <summary>
        /// Returns all accounts from the database.
        /// </summary>
        public Task<List<Account>> GetAllAccountsAsync() => _repo.GetAllAsync();

        /// <summary>
        /// Gets a single account by its ID.
        /// </summary>
        public Task<Account?> GetAccountByIdAsync(int id) => _repo.GetByIdAsync(id);

        /// <summary>
        /// Searches for accounts by company name.
        /// </summary>
        public Task<List<Account>> SearchAccountsAsync(string companyName) =>
            _repo.SearchByCompanyNameAsync(companyName);

        /// <summary>
        /// Creates a new account.
        /// </summary>
        public Task CreateAccountAsync(Account account) => _repo.AddAsync(account);

        /// <summary>
        /// Updates an existing account and logs all changes.
        /// </summary>
        public async Task UpdateAccountAsync(Account updated)
        {
            var existing = await _repo.GetByIdAsync(updated.AccountId);
            if (existing == null) return;

            await TrackAndLogChange("CompanyName", existing.CompanyName, updated.CompanyName, existing.AccountId);
            await TrackAndLogChange("Country", existing.Country, updated.Country, existing.AccountId);
            await TrackAndLogChange("Is2FAEnabled", existing.Is2FAEnabled, updated.Is2FAEnabled, existing.AccountId);
            await TrackAndLogChange("IsIPFilterEnabled", existing.IsIPFilterEnabled, updated.IsIPFilterEnabled, existing.AccountId);
            await TrackAndLogChange("IsSessionTimeoutEnabled", existing.IsSessionTimeoutEnabled, updated.IsSessionTimeoutEnabled, existing.AccountId);
            await TrackAndLogChange("SessionTimeOut", existing.SessionTimeOut, updated.SessionTimeOut, existing.AccountId);
            await TrackAndLogChange("LocalTimeZone", existing.LocalTimeZone, updated.LocalTimeZone, existing.AccountId);
            await TrackAndLogChange("IsActive", existing.IsActive, updated.IsActive, existing.AccountId);

            existing.CompanyName = updated.CompanyName;
            existing.Country = updated.Country;
            existing.Is2FAEnabled = updated.Is2FAEnabled;
            existing.IsIPFilterEnabled = updated.IsIPFilterEnabled;
            existing.IsSessionTimeoutEnabled = updated.IsSessionTimeoutEnabled;
            existing.SessionTimeOut = updated.SessionTimeOut;
            existing.LocalTimeZone = updated.LocalTimeZone;
            existing.IsActive = updated.IsActive;

            await _repo.UpdateAsync(existing);
        }

        /// <summary>
        /// Deletes an account by its ID.
        /// </summary>
        public async Task DeleteAccountAsync(int accountId)
        {
            var account = await _repo.GetByIdAsync(accountId);
            if (account != null)
            {
                await _repo.DeleteAsync(account);
            }
        }

        /// <summary>
        /// Enables or disables an account and logs the change.
        /// </summary>
        public async Task ToggleAccountStatusAsync(int accountId, bool isActive)
        {
            var account = await _repo.GetByIdAsync(accountId);
            if (account == null) return;

            if (account.IsActive != isActive)
            {
                await _logService.LogChangeAsync(accountId, "IsActive", account.IsActive.ToString(), isActive.ToString());
                account.IsActive = isActive;
                await _repo.UpdateAsync(account);
            }
        }

        /// <summary>
        /// Helper method for logging changes to fields.
        /// </summary>
        private async Task TrackAndLogChange<T>(string field, T oldValue, T newValue, int accountId)
        {
            if (!Equals(oldValue, newValue))
            {
                await _logService.LogChangeAsync(accountId, field, oldValue?.ToString(), newValue?.ToString());
            }
        }
    }
}
