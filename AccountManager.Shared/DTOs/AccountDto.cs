using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Shared.DTOs
{
    public class AccountDto
    {
        public int AccountId { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
        public string CompanyName { get; set; }
        public string? Country { get; set; }
        public bool Is2FAEnabled { get; set; }
        public bool IsIPFilterEnabled { get; set; }
        public bool IsSessionTimeoutEnabled { get; set; }
        public int SessionTimeOut { get; set; }
        public string? LocalTimeZone { get; set; }
        public int SubscriptionId { get; set; }
        public DateTime CreatedAt { get; set; }

        public AccountSubscriptionDto? Subscription { get; set; }
    }
}
