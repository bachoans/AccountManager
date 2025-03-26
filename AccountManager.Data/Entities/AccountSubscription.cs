using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Data.Entities
{
    public class AccountSubscription
    {
        [Key]
        public int AccountSubscriptionId { get; set; }

        /// <summary>ID of the selected subscription plan.</summary>
        public int SubscriptionId { get; set; }

        /// <summary>Navigation to the Subscription entity.</summary>
        public virtual Subscription Subscription { get; set; }

        /// <summary>ID of the related account.</summary>
        public int AccountId { get; set; }

        /// <summary>Navigation to the Account entity.</summary>
        public virtual Account Account { get; set; }

        /// <summary>ID of the current subscription status.</summary>
        [ForeignKey("AccountSubscriptionStatus")]
        public int SubscriptionStatusId { get; set; }

        /// <summary>Navigation to the subscription status entity.</summary>
        public virtual AccountSubscriptionStatus AccountSubscriptionStatus { get; set; }

        /// <summary>Whether 2FA is allowed for this subscription.</summary>
        public bool Is2FAAllowed { get; set; }

        /// <summary>Whether IP filtering is allowed.</summary>
        public bool IsIPFilterAllowed { get; set; }

        /// <summary>Whether session timeout is allowed.</summary>
        public bool IsSessionTimeoutAllowed { get; set; }
    }
}
