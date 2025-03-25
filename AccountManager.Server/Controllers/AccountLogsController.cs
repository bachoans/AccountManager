using Microsoft.AspNetCore.Mvc;
using AccountManager.Shared.Services;
using AccountManager.Shared.DTOs;
using AccountManager.Data.Entities;
using AccountManager.Shared.Interfaces;

namespace AccountManager.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountLogsController : ControllerBase
    {
        private readonly IAccountLogService _logService;

        public AccountLogsController(IAccountLogService logService)
        {
            _logService = logService;
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetLogs(int accountId)
        {
            var logs = await _logService.GetAccountLogsAsync(accountId);
            return Ok(logs);
        }
    }
}