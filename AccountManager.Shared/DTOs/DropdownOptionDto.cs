﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManager.Shared.DTOs
{
    /// <summary>
    /// Represents a generic dropdown option (used in UI).
    /// </summary>
    public class DropdownOptionDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}