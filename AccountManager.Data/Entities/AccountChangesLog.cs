using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Data.Entities
{
    public class AccountChangesLog
    {
        [Key]
        public int Id { get; set; }

        /// <summary>The ID of the account that was changed.</summary>
        public int AccountId { get; set; }

        /// <summary>The name of the field that was changed.</summary>
        [Required]
        public string ChangedField { get; set; }

        /// <summary>The previous value before the change.</summary>
        public string? OldValue { get; set; }

        /// <summary>The new value after the change.</summary>
        public string? NewValue { get; set; }

        /// <summary>The time when the change was made (UTC).</summary>
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        /// <summary>Navigation reference to the related Account.</summary>
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
    }
}
