using System.Net.Http.Json;
using AccountManager.Shared.DTOs;

namespace AccountManager.Client.Services
{
    public class AccountApiService
    {
        private readonly HttpClient _http;

        public AccountApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<AccountDto>> GetAccountsAsync()
        {
            return await _http.GetFromJsonAsync<List<AccountDto>>("api/accounts");
        }

        public async Task<AccountDto?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<AccountDto>($"api/accounts/{id}");
        }

        public async Task CreateAsync(SaveAccountDto dto)
        {
            await _http.PostAsJsonAsync("api/accounts", dto);
        }

        public async Task UpdateAsync(int id, SaveAccountDto dto)
        {
            await _http.PutAsJsonAsync($"api/accounts/{id}", dto);
        }

        public async Task DeleteAsync(int id)
        {
            await _http.DeleteAsync($"api/accounts/{id}");
        }

        public async Task ToggleAsync(int id, bool isActive)
        {
            await _http.PatchAsync($"api/accounts/{id}/toggle?isActive={isActive}", null);
        }

        public async Task<List<AccountDto>> SearchAccountsAsync(string name)
        {
            return await _http.GetFromJsonAsync<List<AccountDto>>($"api/accounts/search?name={Uri.EscapeDataString(name)}");
        }

    }
}
