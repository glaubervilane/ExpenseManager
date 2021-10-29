﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }

        public int MonthId { get; set; }

        public Month Month { get; set; }

        public int ExpenseTypeId { get; set; }
        public ExpenseType ExpenseType { get; set; }

        [Required(ErrorMessage = "Mandatory Field.")]
        [Range(0, double.MaxValue, ErrorMessage = "Invalid Value.")]
        public double Value { get; set; }
    }
}
