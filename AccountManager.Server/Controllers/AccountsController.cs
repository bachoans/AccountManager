using Microsoft.AspNetCore.Mvc;
using AccountManager.Shared.Services;
using AccountManager.Shared.DTOs;
using AccountManager.Data.Entities;
using AccountManager.Shared.Interfaces;

namespace AccountManager.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ISubscriptionService _subscriptionService;
        private readonly IAccountLogService _logService;

        public AccountsController(
            IAccountService accountService,
            ISubscriptionService subscriptionService,
            IAccountLogService logService)
        {
            _accountService = accountService;
            _subscriptionService = subscriptionService;
            _logService = logService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Account>>> GetAll()
        {
            var result = await _accountService.GetAllAccountsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetById(int id)
        {
            var account = await _accountService.GetAccountByIdAsync(id);
            if (account == null) return NotFound();
            return Ok(account);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<Account>>> Search([FromQuery] string name)
        {
            var result = await _accountService.SearchAccountsAsync(name);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveAccountDto dto)
        {
            if (dto.AccountId.HasValue)
                return BadRequest("AccountId should be null for creation.");

            var account = new Account
            {
                CompanyName = dto.CompanyName,
                Country = dto.Country,
                Is2FAEnabled = dto.Is2FAEnabled,
                IsIPFilterEnabled = dto.IsIPFilterEnabled,
                IsSessionTimeoutEnabled = dto.IsSessionTimeoutEnabled,
                SessionTimeOut = dto.SessionTimeOut,
                LocalTimeZone = dto.LocalTimeZone,
                IsActive = dto.IsActive
            };

            await _accountService.CreateAccountAsync(account);

            var subscription = new AccountSubscription
            {
                AccountId = account.AccountId,
                SubscriptionId = dto.SubscriptionId,
                SubscriptionStatusId = dto.SubscriptionStatusId,
                Is2FAAllowed = true, // Default logic can go here
                IsIPFilterAllowed = true,
                IsSessionTimeoutAllowed = true
            };

            await _subscriptionService.SetAccountSubscriptionAsync(subscription);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SaveAccountDto dto)
        {
            if (dto.AccountId != id)
                return BadRequest("Mismatched AccountId.");

            var existing = await _accountService.GetAccountByIdAsync(id);
            if (existing == null) return NotFound();

            // Log changes
            if (existing.CompanyName != dto.CompanyName)
                await _logService.LogChangeAsync(id, "CompanyName", existing.CompanyName, dto.CompanyName);
            if (existing.Country != dto.Country)
                await _logService.LogChangeAsync(id, "Country", existing.Country, dto.Country);
            if (existing.Is2FAEnabled != dto.Is2FAEnabled)
                await _logService.LogChangeAsync(id, "Is2FAEnabled", existing.Is2FAEnabled.ToString(), dto.Is2FAEnabled.ToString());
            if (existing.IsIPFilterEnabled != dto.IsIPFilterEnabled)
                await _logService.LogChangeAsync(id, "IsIPFilterEnabled", existing.IsIPFilterEnabled.ToString(), dto.IsIPFilterEnabled.ToString());
            if (existing.IsSessionTimeoutEnabled != dto.IsSessionTimeoutEnabled)
                await _logService.LogChangeAsync(id, "IsSessionTimeoutEnabled", existing.IsSessionTimeoutEnabled.ToString(), dto.IsSessionTimeoutEnabled.ToString());
            if (existing.LocalTimeZone != dto.LocalTimeZone)
                await _logService.LogChangeAsync(id, "LocalTimeZone", existing.LocalTimeZone, dto.LocalTimeZone);
            if (existing.IsActive != dto.IsActive)
                await _logService.LogChangeAsync(id, "IsActive", existing.IsActive.ToString(), dto.IsActive.ToString());
            //TODO: Log Subscription change
            
            existing.CompanyName = dto.CompanyName;
            existing.Country = dto.Country;
            existing.Is2FAEnabled = dto.Is2FAEnabled;
            existing.IsIPFilterEnabled = dto.IsIPFilterEnabled;
            existing.IsSessionTimeoutEnabled = dto.IsSessionTimeoutEnabled;
            existing.SessionTimeOut = dto.SessionTimeOut;
            existing.LocalTimeZone = dto.LocalTimeZone;
            existing.IsActive = dto.IsActive;

            await _accountService.UpdateAccountAsync(existing);

            var subscription = new AccountSubscription
            {
                AccountId = id,
                SubscriptionId = dto.SubscriptionId,
                SubscriptionStatusId = dto.SubscriptionStatusId,
                Is2FAAllowed = true,
                IsIPFilterAllowed = true,
                IsSessionTimeoutAllowed = true
            };

            await _subscriptionService.SetAccountSubscriptionAsync(subscription);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _accountService.DeleteAccountAsync(id);
            return NoContent();
        }

        [HttpPatch("{id}/toggle")]
        public async Task<IActionResult> Toggle(int id, [FromQuery] bool isActive)
        {
            await _accountService.ToggleAccountStatusAsync(id, isActive);
            return Ok();
        }
    }
}
