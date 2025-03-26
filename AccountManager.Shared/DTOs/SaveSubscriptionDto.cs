using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Shared.DTOs
{
    /// <summary>
    /// Represents data used to create a new subscription plan.
    /// </summary>
    public class SaveSubscriptionDto
    {
        [Required]
        public string Description { get; set; } = string.Empty;

        public bool Is2FAAllowed { get; set; }
        public bool IsIPFilterAllowed { get; set; }
        public bool IsSessionTimeoutAllowed { get; set; }
    }
}
