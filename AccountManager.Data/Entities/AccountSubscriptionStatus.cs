﻿using System;
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

        public string Description { get; set; }

        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsDeleted { get; set; }
    }
}
