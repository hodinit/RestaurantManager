using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantManager.Data;
using RestaurantManager.Models;

namespace RestaurantManager.Controllers
{
    public class UtensilsController : Controller
    {
        private readonly RestaurantManagerContext _context;

        public UtensilsController(RestaurantManagerContext context)
        {
            _context = context;
        }

        // GET: Utensils
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utensil.ToListAsync());
        }

        // GET: Utensils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utensil = await _context.Utensil
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utensil == null)
            {
                return NotFound();
            }

            return View(utensil);
        }

        // GET: Utensils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utensils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Material,Ease_of_cleaning")] Utensil utensil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utensil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utensil);
        }

        // GET: Utensils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utensil = await _context.Utensil.FindAsync(id);
            if (utensil == null)
            {
                return NotFound();
            }
            return View(utensil);
        }

        // POST: Utensils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Material,Ease_of_cleaning")] Utensil utensil)
        {
            if (id != utensil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utensil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtensilExists(utensil.Id))
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
            return View(utensil);
        }

        // GET: Utensils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utensil = await _context.Utensil
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utensil == null)
            {
                return NotFound();
            }

            return View(utensil);
        }

        // POST: Utensils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utensil = await _context.Utensil.FindAsync(id);
            if (utensil != null)
            {
                _context.Utensil.Remove(utensil);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtensilExists(int id)
        {
            return _context.Utensil.Any(e => e.Id == id);
        }
    }
}
