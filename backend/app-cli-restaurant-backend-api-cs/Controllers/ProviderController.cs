/*
 * @fileoverview    {ProviderController}
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

namespace Restaurant.Controllers
{
    public class ProviderController : Controller
    {
        private readonly RestaurantContext _context;

        public ProviderController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Provider
        public async Task<IActionResult> Index()
        {
            return View(await _context.Provider.ToListAsync());
        }

        // GET: Provider/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Provider == null)
            {
                return NotFound();
            }

            var provider = await _context.Provider
                .FirstOrDefaultAsync(m => m.IntProviderId == id);
            if (provider == null)
            {
                return NotFound();
            }

            return View(provider);
        }

        // GET: Provider/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Provider/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntProviderId,IntIngredientId,IntSupplierId")] Provider provider)
        {
            if (ModelState.IsValid)
            {
                _context.Add(provider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(provider);
        }

        // GET: Provider/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Provider == null)
            {
                return NotFound();
            }

            var provider = await _context.Provider.FindAsync(id);
            if (provider == null)
            {
                return NotFound();
            }
            return View(provider);
        }

        // POST: Provider/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntProviderId,IntIngredientId,IntSupplierId")] Provider provider)
        {
            if (id != provider.IntProviderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(provider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProviderExists(provider.IntProviderId))
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
            return View(provider);
        }

        // GET: Provider/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Provider == null)
            {
                return NotFound();
            }

            var provider = await _context.Provider
                .FirstOrDefaultAsync(m => m.IntProviderId == id);
            if (provider == null)
            {
                return NotFound();
            }

            return View(provider);
        }

        // POST: Provider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.Provider == null)
            {
                return Problem("Entity set 'RestaurantContext.Provider'  is null.");
            }
            var provider = await _context.Provider.FindAsync(id);
            if (provider != null)
            {
                _context.Provider.Remove(provider);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProviderExists(long? id)
        {
            return _context.Provider.Any(e => e.IntProviderId == id);
        }
    }
}
