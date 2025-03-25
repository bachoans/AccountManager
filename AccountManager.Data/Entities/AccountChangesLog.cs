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

        public int AccountId { get; set; }

        [Required]
        public string ChangedField { get; set; }

        public string? OldValue { get; set; }
        public string? NewValue { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
    }
}
