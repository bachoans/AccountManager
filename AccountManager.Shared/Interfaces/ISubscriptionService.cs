using AccountManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Shared.Interfaces
{
    public interface ISubscriptionService
    {
        Task<List<Subscription>> GetAllSubscriptionsAsync();
        Task<AccountSubscription?> GetAccountSubscriptionAsync(int accountId);
        Task SetAccountSubscriptionAsync(AccountSubscription subscription);
    }
}
