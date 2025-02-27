/*
 * @fileoverview    {SupplierController}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementation done.
 * @version 2.0     Documentation added.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Restaurant.Data;

namespace Restaurant.Controllers {

    /**
     * TODO: Description of {@code SupplierController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class SupplierController : Controller {
        private readonly RestaurantContext _context;

        /**
         * TODO: Description of method {@code SupplierController}.
         *
         */
        public SupplierController(RestaurantContext context) {
            _context = context;
        }

        /**
         * GET: Supplier
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Supplier.ToListAsync());
        }

        /**
         * GET: Supplier/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.Supplier == null) {
                return NotFound();
            }

            var supplier = await _context.Supplier
                .FirstOrDefaultAsync(m => m.IntSupplierId == id);
            if (supplier == null) {
                return NotFound();
            }

            return View(supplier);
        }

        /**
         * GET: Supplier/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Supplier/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntSupplierId,StrSupplierCity,TxtSupplierName,IntPhone,IntChefId")] Supplier supplier) {
            if (ModelState.IsValid) {
                _context.Add(supplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        /**
         * GET: Supplier/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.Supplier == null) {
                return NotFound();
            }

            var supplier = await _context.Supplier.FindAsync(id);
            if (supplier == null) {
                return NotFound();
            }
            return View(supplier);
        }

        /**
         * POST: Supplier/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntSupplierId,StrSupplierCity,TxtSupplierName,IntPhone,IntChefId")] Supplier supplier) {
            if (id != supplier.IntSupplierId) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(supplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!SupplierExists(supplier.IntSupplierId)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        /**
         * GET: Supplier/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.Supplier == null) {
                return NotFound();
            }

            var supplier = await _context.Supplier
                .FirstOrDefaultAsync(m => m.IntSupplierId == id);
            if (supplier == null) {
                return NotFound();
            }

            return View(supplier);
        }

        /**
         * POST: Supplier/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.Supplier == null) {
                return Problem("Entity set 'RestaurantContext.Supplier'  is null.");
            }
            var supplier = await _context.Supplier.FindAsync(id);
            if (supplier != null) {
                _context.Supplier.Remove(supplier);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code SupplierExists}.
         *
         */
        private bool SupplierExists(long? id) {
            return _context.Supplier.Any(e => e.IntSupplierId == id);
        }
    }
}
