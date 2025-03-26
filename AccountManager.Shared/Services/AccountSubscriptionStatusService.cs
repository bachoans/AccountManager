using AccountManager.Data.Interfaces;
using AccountManager.Shared.DTOs;
using AccountManager.Shared.Interfaces;

namespace AccountManager.Shared.Services
{
    /// <summary>
    /// Service to get available subscription statuses (like Active, Paused).
    /// </summary>
    public class AccountSubscriptionStatusService : IAccountSubscriptionStatusService
    {
        private readonly IAccountSubscriptionStatusRepository _repo;

        public AccountSubscriptionStatusService(IAccountSubscriptionStatusRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Gets all subscription statuses.
        /// </summary
        public async Task<List<SubscriptionStatusDto>> GetAllAsync()
        {
            var statuses = await _repo.GetAllAsync();
            return statuses.Select(s => new SubscriptionStatusDto
            {
                SubscriptionStatusId = s.SubscriptionStatusId,
                Description = s.Description
            }).ToList();
        }
    }
}
