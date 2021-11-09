using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.ViewModels
{
    public class StatisticsViewModel
    {
        public int QuantityExpenses { get; set; }

        public double LowerExpense { get; set; }

        public double GreatestExpense { get; set; }
    }
}
