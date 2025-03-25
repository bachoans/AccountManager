using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Shared.DTOs
{
    public class SaveAccountDto
    {
        public int? AccountId { get; set; }

        [Required]
        public string CompanyName { get; set; } = string.Empty;

        public string? Country { get; set; }

        public bool Is2FAEnabled { get; set; }
        public bool IsIPFilterEnabled { get; set; }
        public bool IsSessionTimeoutEnabled { get; set; }

        [Range(0, 240, ErrorMessage = "Timeout must be between 0 and 240 minutes")]
        public int SessionTimeOut { get; set; }

        public string? LocalTimeZone { get; set; }

        [Required(ErrorMessage = "Subscription is required")]
        public int SubscriptionId { get; set; }

        public int SubscriptionStatusId { get; set; } = 1;

        public bool IsActive { get; set; } = true;
    }
}
