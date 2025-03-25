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
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepo;
        private readonly IAccountSubscriptionRepository _accountSubRepo;

        public SubscriptionService(
            ISubscriptionRepository subscriptionRepo,
            IAccountSubscriptionRepository accountSubRepo)
        {
            _subscriptionRepo = subscriptionRepo;
            _accountSubRepo = accountSubRepo;
        }

        public Task<List<Subscription>> GetAllSubscriptionsAsync() =>
            _subscriptionRepo.GetAllAsync();

        public Task<AccountSubscription?> GetAccountSubscriptionAsync(int accountId) =>
            _accountSubRepo.GetByAccountIdAsync(accountId);

        public Task SetAccountSubscriptionAsync(AccountSubscription subscription) =>
            _accountSubRepo.AddOrUpdateAsync(subscription);
    }
}
