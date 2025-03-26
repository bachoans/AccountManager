using Microsoft.AspNetCore.Mvc;
using AccountManager.Data.Entities;
using AccountManager.Shared.Interfaces;
using AccountManager.Shared.DTOs;

namespace AccountManager.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionStatusesController : ControllerBase
    {
        private readonly IAccountSubscriptionStatusService _service;

        public SubscriptionStatusesController(IAccountSubscriptionStatusService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubscriptionStatusDto>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
    }
}
