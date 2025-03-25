using AccountManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Shared.Interfaces
{
    public interface IAccountLogService
    {
        Task LogChangeAsync(int accountId, string field, string? oldValue, string? newValue);
        Task<List<AccountChangesLog>> GetAccountLogsAsync(int accountId);
    }
}
