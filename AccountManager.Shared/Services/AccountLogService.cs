﻿using AccountManager.Data.Entities;
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
    /// Handles logging of account changes and retrieving change history.
    /// </summary>
    public class AccountLogService : IAccountLogService
    {
        private readonly IAccountChangesLogRepository _logRepo;

        public AccountLogService(IAccountChangesLogRepository logRepo)
        {
            _logRepo = logRepo;
        }

        /// <summary>
        /// Gets the list of changes for the given account.
        /// </summary>
        public Task<List<AccountChangesLog>> GetAccountLogsAsync(int accountId) =>
            _logRepo.GetLogsByAccountIdAsync(accountId);

        /// <summary>
        /// Logs a change to a specific field of an account.
        /// </summary>
        public Task LogChangeAsync(int accountId, string field, string? oldValue, string? newValue)
        {
            var log = new AccountChangesLog
            {
                AccountId = accountId,
                ChangedField = field,
                OldValue = oldValue,
                NewValue = newValue,
                Timestamp = DateTime.UtcNow
            };

            return _logRepo.LogChangeAsync(log);
        }
    }
}
