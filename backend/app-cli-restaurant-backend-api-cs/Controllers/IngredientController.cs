/*
 * @overview        {IngredientController}
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
     * TODO: Description of {@code IngredientController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class IngredientController : Controller {
        private readonly RestaurantContext _context;

        /**
         * TODO: Description of method {@code IngredientController}.
         *
         */
        public IngredientController(RestaurantContext context) {
            _context = context;
        }

        /**
         * GET: Ingredient
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Ingredient.ToListAsync());
        }

        /**
         * GET: Ingredient/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.Ingredient == null) {
                return NotFound();
            }

            var ingredient = await _context.Ingredient
                .FirstOrDefaultAsync(m => m.IntIngredientId == id);
            if (ingredient == null) {
                return NotFound();
            }

            return View(ingredient);
        }

        /**
         * GET: Ingredient/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Ingredient/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIngredientId,StrIngredientName,StrDescription,IntMealId")] Ingredient ingredient) {
            if (ModelState.IsValid) {
                _context.Add(ingredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ingredient);
        }

        /**
         * GET: Ingredient/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.Ingredient == null) {
                return NotFound();
            }

            var ingredient = await _context.Ingredient.FindAsync(id);
            if (ingredient == null) {
                return NotFound();
            }
            return View(ingredient);
        }

        /**
         * POST: Ingredient/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIngredientId,StrIngredientName,StrDescription,IntMealId")] Ingredient ingredient) {
            if (id != ingredient.IntIngredientId) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(ingredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!IngredientExists(ingredient.IntIngredientId)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ingredient);
        }

        /**
         * GET: Ingredient/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.Ingredient == null) {
                return NotFound();
            }

            var ingredient = await _context.Ingredient
                .FirstOrDefaultAsync(m => m.IntIngredientId == id);
            if (ingredient == null) {
                return NotFound();
            }

            return View(ingredient);
        }

        /**
         * POST: Ingredient/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.Ingredient == null) {
                return Problem("Entity set 'RestaurantContext.Ingredient'  is null.");
            }
            var ingredient = await _context.Ingredient.FindAsync(id);
            if (ingredient != null) {
                _context.Ingredient.Remove(ingredient);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code IngredientExists}.
         *
         */
        private bool IngredientExists(long? id) {
            return _context.Ingredient.Any(e => e.IntIngredientId == id);
        }
    }
}
