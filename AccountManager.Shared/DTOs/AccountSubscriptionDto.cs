using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Shared.DTOs
{
    public class AccountSubscriptionDto
    {
        public int SubscriptionId { get; set; }
        public string? Description { get; set; }
        public int SubscriptionStatusId { get; set; }
        public string StatusDescription { get; set; }

        public bool Is2FAAllowed { get; set; }
        public bool IsIPFilterAllowed { get; set; }
        public bool IsSessionTimeoutAllowed { get; set; }
    }
}
