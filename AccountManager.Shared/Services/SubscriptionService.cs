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
    /// Handles business logic related to subscriptions and account subscription settings.
    /// </summary>
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

        /// <summary>
        /// Gets all available subscriptions.
        /// </summary>
        public Task<List<Subscription>> GetAllSubscriptionsAsync() =>
            _subscriptionRepo.GetAllAsync();

        /// <summary>
        /// Gets subscription details for a given account.
        /// </summary>
        public Task<AccountSubscription?> GetAccountSubscriptionAsync(int accountId) =>
            _accountSubRepo.GetByAccountIdAsync(accountId);

        /// <summary>
        /// Creates or updates subscription settings for an account.
        /// </summary>
        public Task SetAccountSubscriptionAsync(AccountSubscription subscription) =>
            _accountSubRepo.AddOrUpdateAsync(subscription);
    }
}
