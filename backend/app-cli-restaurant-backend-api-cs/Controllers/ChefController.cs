/*
 * @fileoverview    {ChefController}
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
    public class ChefController : Controller
    {
        private readonly RestaurantContext _context;

        public ChefController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Chef
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chef.ToListAsync());
        }

        // GET: Chef/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Chef == null)
            {
                return NotFound();
            }

            var chef = await _context.Chef
                .FirstOrDefaultAsync(m => m.IntChefId == id);
            if (chef == null)
            {
                return NotFound();
            }

            return View(chef);
        }

        // GET: Chef/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chef/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntChefId,StrChefName,FltSalary")] Chef chef)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chef);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chef);
        }

        // GET: Chef/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Chef == null)
            {
                return NotFound();
            }

            var chef = await _context.Chef.FindAsync(id);
            if (chef == null)
            {
                return NotFound();
            }
            return View(chef);
        }

        // POST: Chef/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntChefId,StrChefName,FltSalary")] Chef chef)
        {
            if (id != chef.IntChefId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chef);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChefExists(chef.IntChefId))
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
            return View(chef);
        }

        // GET: Chef/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Chef == null)
            {
                return NotFound();
            }

            var chef = await _context.Chef
                .FirstOrDefaultAsync(m => m.IntChefId == id);
            if (chef == null)
            {
                return NotFound();
            }

            return View(chef);
        }

        // POST: Chef/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.Chef == null)
            {
                return Problem("Entity set 'RestaurantContext.Chef'  is null.");
            }
            var chef = await _context.Chef.FindAsync(id);
            if (chef != null)
            {
                _context.Chef.Remove(chef);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChefExists(long? id)
        {
            return _context.Chef.Any(e => e.IntChefId == id);
        }
    }
}
