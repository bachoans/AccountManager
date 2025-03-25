using Microsoft.AspNetCore.Mvc;
using AccountManager.Shared.Services;
using AccountManager.Shared.DTOs;
using AccountManager.Data.Entities;
using AccountManager.Shared.Interfaces;

namespace AccountManager.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionsController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _subscriptionService.GetAllSubscriptionsAsync();
            return Ok(list);
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetByAccountId(int accountId)
        {
            var sub = await _subscriptionService.GetAccountSubscriptionAsync(accountId);
            return Ok(sub);
        }
    }
}
