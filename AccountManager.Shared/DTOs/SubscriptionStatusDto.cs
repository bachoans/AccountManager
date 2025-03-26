using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Shared.DTOs
{
    /// <summary>
    /// Represents a status label for a subscription (e.g. Active, Cancelled).
    /// </summary>
    public class SubscriptionStatusDto
    {
        public int SubscriptionStatusId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
