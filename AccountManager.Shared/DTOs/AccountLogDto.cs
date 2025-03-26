using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Shared.DTOs
{
    /// <summary>
    /// Represents a change made to an account, used in change log display.
    /// </summary>
    public class AccountLogDto
    {
        public string ChangedField { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
