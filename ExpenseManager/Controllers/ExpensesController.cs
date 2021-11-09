using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenseManager.Models;
using X.PagedList;
using ExpenseManager.ViewModels;

namespace ExpenseManager.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly Context _context;

        public ExpensesController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? page)
        {
            const int pageItems = 10;
            int pageNumber = (page ?? 1);

            ViewData["Months"] = new SelectList(_context.Months.Where(x => x.MonthId == x.Salary.MonthId), "MonthId", "Name");

            var context = _context.Expenses.Include(e => e.ExpenseType).Include(e => e.Month).OrderBy(e => e.MonthId);
            return View(await context.ToPagedListAsync(pageNumber, pageItems));
        }

        public IActionResult Create()
        {
            ViewData["MonthId"] = new SelectList(_context.Months, "MonthId", "Name");
            ViewData["ExpenseTypeId"] = new SelectList(_context.ExpenseTypes, "ExpenseTypeId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExpenseId,MonthId,ExpenseTypeId,Value")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                TempData["Confirmation"] = "Expense Registered Successfully.";

                _context.Add(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MonthId"] = new SelectList(_context.Months, "MonthId", "Name", expense.MonthId);
            ViewData["ExpenseTypeId"] = new SelectList(_context.ExpenseTypes, "ExpenseTypeId", "Name", expense.ExpenseTypeId);
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            ViewData["MonthId"] = new SelectList(_context.Months, "MonthId", "Name", expense.MonthId);
            ViewData["ExpenseTypeId"] = new SelectList(_context.ExpenseTypes, "ExpenseTypeId", "Name", expense.ExpenseTypeId);
            return View(expense);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExpenseId,MonthId,ExpenseTypeId,Value")] Expense expense)
        {
            if (id != expense.ExpenseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Confirmation"] = "Expense Updated Successfully.";
                    _context.Update(expense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseExists(expense.ExpenseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MonthId"] = new SelectList(_context.Months, "MonthId", "Name", expense.MonthId);
            ViewData["ExpenseTypeId"] = new SelectList(_context.ExpenseTypes, "ExpenseTypeId", "Name", expense.ExpenseTypeId);
            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseExists(int id)
        {
            return _context.Expenses.Any(e => e.ExpenseId == id);
        }

        public JsonResult TotalSpendingMonths(int monthId)
        {
            TotalExpendituresMonthViewModel spending = new TotalExpendituresMonthViewModel();

            spending.TotalAmountExpenditure = _context.Expenses.Where(d => d.Month.MonthId == monthId).Sum(d => d.Value);
            spending.Salary = _context.Salaries.Where(s => s.Month.MonthId == monthId).Select(s => s.Value).FirstOrDefault();

            return Json(spending);
        }

        public JsonResult MonthExpense(int monthId)
        {
            var query = from expenses in _context.Expenses
                        where expenses.Month.MonthId == monthId
                        group expenses by expenses.ExpenseType.Name into g
                        select new
                        {
                            ExpenseType = g.Key,
                            Value = g.Sum(d => d.Value)
                        };

            return Json(query);
        }

        public JsonResult TotalExpenses()
        {
            var query = _context.Expenses
                .OrderBy(m => m.Month.MonthId)
                .GroupBy(m => m.Month.MonthId)
                .Select(d => new { NameMonths = d.Select(x => x.Month.Name).Distinct(), Value = d.Sum(x => x.Value) });

            return Json(query);
        }
    }
}
