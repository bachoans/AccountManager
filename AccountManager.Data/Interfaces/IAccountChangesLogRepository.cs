﻿using AccountManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Data.Interfaces
{
    public interface IAccountChangesLogRepository
    {
        Task<List<AccountChangesLog>> GetLogsByAccountIdAsync(int accountId);
        Task LogChangeAsync(AccountChangesLog log);
    }
}
