using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Data.Entities
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [MaxLength(128)]
        public string Token { get; set; } = Guid.NewGuid().ToString();

        public bool IsActive { get; set; } =  false;

        [MaxLength(100)]
        public string CompanyName { get; set; }

        [MaxLength(50)]
        public string? Country { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool Is2FAEnabled { get; set; }
        public bool IsIPFilterEnabled { get; set; }
        public bool IsSessionTimeoutEnabled { get; set; }

        public int SessionTimeOut { get; set; }

        [MaxLength(100)]
        public string? LocalTimeZone { get; set; }

        public virtual AccountSubscription? AccountSubscriptions { get; set; }
    }
}
