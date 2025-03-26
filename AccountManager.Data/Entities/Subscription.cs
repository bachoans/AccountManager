using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Data.Entities
{
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; }

        /// <summary>Text description of the subscription plan (e.g., Basic, Pro).</summary>
        [MaxLength(100)]
        public string? Description { get; set; }

        /// <summary>Whether this plan is the default selection.</summary>
        public bool IsDefault { get; set; }

        /// <summary>Whether this plan is active and usable.</summary>
        public bool IsActive { get; set; }

        /// <summary>Whether this plan is available for yearly billing.</summary>
        public bool AvailableYearly { get; set; }

        /// <summary>Whether this plan allows two-factor authentication.</summary>
        public bool Is2FAAllowed { get; set; }

        /// <summary>Whether this plan allows IP filtering.</summary>
        public bool IsIPFilterAllowed { get; set; }

        /// <summary>Whether this plan allows session timeout configuration.</summary>
        public bool IsSessionTimeoutAllowed { get; set; }
    }
}
