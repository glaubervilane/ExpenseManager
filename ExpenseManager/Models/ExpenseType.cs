using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.Models
{
    public class ExpenseType
    {
        public int ExpenseTypeId { get; set; }

        [Required(ErrorMessage = "Mandatory Field.")]
        [StringLength(50, ErrorMessage = "Use Less Characters.")]
        public string Name { get; set; }

        public ICollection<Expense> Expense { get; set; }
    }
}
