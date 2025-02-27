/*
 * @fileoverview    {WaiterController}
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
     * TODO: Description of {@code WaiterController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class WaiterController : Controller {
        private readonly RestaurantContext _context;

        /**
         * TODO: Description of method {@code WaiterController}.
         *
         */
        public WaiterController(RestaurantContext context) {
            _context = context;
        }

        /**
         * GET: Waiter
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Waiter.ToListAsync());
        }

        /**
         * GET: Waiter/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.Waiter == null) {
                return NotFound();
            }

            var waiter = await _context.Waiter
                .FirstOrDefaultAsync(m => m.IntWaiterId == id);
            if (waiter == null) {
                return NotFound();
            }

            return View(waiter);
        }

        /**
         * GET: Waiter/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Waiter/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntWaiterId,StrWaiterName,FltSalary,IntPhone")] Waiter waiter) {
            if (ModelState.IsValid) {
                _context.Add(waiter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(waiter);
        }

        /**
         * GET: Waiter/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.Waiter == null) {
                return NotFound();
            }

            var waiter = await _context.Waiter.FindAsync(id);
            if (waiter == null) {
                return NotFound();
            }
            return View(waiter);
        }

        /**
         * POST: Waiter/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntWaiterId,StrWaiterName,FltSalary,IntPhone")] Waiter waiter) {
            if (id != waiter.IntWaiterId) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(waiter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!WaiterExists(waiter.IntWaiterId)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(waiter);
        }

        /**
         * GET: Waiter/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.Waiter == null) {
                return NotFound();
            }

            var waiter = await _context.Waiter
                .FirstOrDefaultAsync(m => m.IntWaiterId == id);
            if (waiter == null) {
                return NotFound();
            }

            return View(waiter);
        }

        /**
         * POST: Waiter/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.Waiter == null) {
                return Problem("Entity set 'RestaurantContext.Waiter'  is null.");
            }
            var waiter = await _context.Waiter.FindAsync(id);
            if (waiter != null) {
                _context.Waiter.Remove(waiter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code WaiterExists}.
         *
         */
        private bool WaiterExists(long? id) {
            return _context.Waiter.Any(e => e.IntWaiterId == id);
        }
    }
}
