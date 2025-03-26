using AccountManager.Data.Entities;
using AccountManager.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Shared.Interfaces
{
    public interface IAccountSubscriptionStatusService
    {
        Task<List<SubscriptionStatusDto>> GetAllAsync();
    }
}
