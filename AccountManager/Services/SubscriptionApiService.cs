using AccountManager.Shared.DTOs;
using System.Net.Http.Json;

namespace AccountManager.Client.Services
{
    public class SubscriptionApiService
    {
        private readonly HttpClient _http;

        public SubscriptionApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<SubscriptionDto>> GetSubscriptionsAsync()
        {
            return await _http.GetFromJsonAsync<List<SubscriptionDto>>("api/subscriptions");
        }

        public async Task AddSubscriptionAsync(SaveSubscriptionDto dto)
        {
            await _http.PostAsJsonAsync("api/subscriptions", dto);
        }

        public async Task DeleteSubscriptionAsync(int id)
        {
            await _http.DeleteAsync($"api/subscriptions/{id}");
        }
    }
}
