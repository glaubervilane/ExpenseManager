using ExpenseManager.Models;
using ExpenseManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.ViewComponents
{
    public class StatisticsViewComponent : ViewComponent
    {
        private readonly Context _context;

        public StatisticsViewComponent(Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            StatisticsViewModel statistics = new StatisticsViewModel();

            statistics.LowerExpense = _context.Expenses.Min(x => x.Value);
            statistics.GreatestExpense = _context.Expenses.Max(x => x.Value);
            statistics.QuantityExpenses = _context.Expenses.Count();

            return View(statistics);
        }
    }
}
