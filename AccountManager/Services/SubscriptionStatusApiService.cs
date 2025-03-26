using System.Net.Http.Json;
using AccountManager.Shared.DTOs;

namespace AccountManager.Client.Services
{
    public class SubscriptionStatusApiService
    {
        private readonly HttpClient _http;

        public SubscriptionStatusApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<SubscriptionStatusDto>> GetStatusesAsync()
        {
            return await _http.GetFromJsonAsync<List<SubscriptionStatusDto>>("api/subscriptionstatuses")
                   ?? new List<SubscriptionStatusDto>();
        }
    }
}
