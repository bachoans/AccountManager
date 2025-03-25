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

        public int SubscriptionId { get; set; }
        public virtual Subscription Subscription { get; set; }

        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        [ForeignKey("AccountSubscriptionStatus")]
        public int SubscriptionStatusId { get; set; }
        public virtual AccountSubscriptionStatus AccountSubscriptionStatus { get; set; }

        public bool Is2FAAllowed { get; set; }
        public bool IsIPFilterAllowed { get; set; }
        public bool IsSessionTimeoutAllowed { get; set; }
    }
}
