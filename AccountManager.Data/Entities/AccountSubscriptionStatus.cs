using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Data.Entities
{
    public class AccountSubscriptionStatus
    {
        [Key]
        public int SubscriptionStatusId { get; set; }

        /// <summary>Text description of the subscription status (e.g., Active, Paused).</summary>
        public string Description { get; set; }

        /// <summary>Whether this status is the default option.</summary>
        public bool IsDefault { get; set; }

        /// <summary>Whether this status is currently active.</summary>
        public bool IsActive { get; set; }

        /// <summary>Whether this status marks the subscription as cancelled.</summary>
        public bool IsCancelled { get; set; }

        /// <summary>Marks the status as deleted (soft delete).</summary>
        public bool IsDeleted { get; set; }
    }
}
