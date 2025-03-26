using AccountManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Data.Interfaces
{
    public interface IAccountSubscriptionStatusRepository
    {
        Task<List<AccountSubscriptionStatus>> GetAllAsync();
    }
}
