using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenseManager.Models;

namespace ExpenseManager.Controllers
{
    public class ExpenseTypesController : Controller
    {
        private readonly Context _context;

        public ExpenseTypesController(Context context)
        {
            _context = context;
        }

        // GET: ExpenseTypes
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExpenseTypes.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string txtSearch)
        {
            if (!String.IsNullOrEmpty(txtSearch))
                return View(await _context.ExpenseTypes.Where(td => td.Name.ToUpper().Contains(txtSearch.ToUpper())).ToListAsync());

            return View(await _context.ExpenseTypes.ToListAsync());
        }

        public async Task<JsonResult> ExpenseTypeExist(string name)
        {
            if (await _context.ExpenseTypes.AnyAsync(td => td.Name.ToUpper() == name.ToUpper()))
                return Json("This Type of Expense Already Exists");

            return Json(true);
        }

        // GET: ExpenseTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExpenseTypeId,Name")] ExpenseType expenseType)
        {
            if (ModelState.IsValid)
            {
                TempData["Confirmation"] = expenseType.Name + " Was Successfully Registered. ";
                _context.Add(expenseType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expenseType);
        }

        // GET: ExpenseTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseType = await _context.ExpenseTypes.FindAsync(id);
            if (expenseType == null)
            {
                return NotFound();
            }
            return View(expenseType);
        }

        // POST: ExpenseTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExpenseTypeId,Name")] ExpenseType expenseType)
        {
            if (id != expenseType.ExpenseTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Confirmation"] = expenseType.Name + " Was Successfully Updated. ";
                    _context.Update(expenseType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseTypeExists(expenseType.ExpenseTypeId))
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
            return View(expenseType);
        }

        // POST: ExpenseTypes/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            var expenseType = await _context.ExpenseTypes.FindAsync(id);
            TempData["Confirmation"] = expenseType.Name + " Was Successfully Deleted. ";
            _context.ExpenseTypes.Remove(expenseType);
            await _context.SaveChangesAsync();
            return Json(expenseType.Name + " deleted successfully.");
        }

        private bool ExpenseTypeExists(int id)
        {
            return _context.ExpenseTypes.Any(e => e.ExpenseTypeId == id);
        }
    }
}
