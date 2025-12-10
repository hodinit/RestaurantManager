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
    public class KitchensController : Controller
    {
        private readonly RestaurantManagerContext _context;

        public KitchensController(RestaurantManagerContext context)
        {
            _context = context;
        }

        // GET: Kitchens
        public async Task<IActionResult> Index()
        {
            var restaurantManagerContext = _context.Kitchen.Include(k => k.Chef).Include(k => k.Utensil).Include(k => k.Location);
            return View(await restaurantManagerContext.ToListAsync());
        }

        // GET: Kitchens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitchen = await _context.Kitchen
                .Include(k => k.Chef)
                .Include(k => k.Utensil)
                .Include(k => k.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kitchen == null)
            {
                return NotFound();
            }

            return View(kitchen);
        }

        // GET: Kitchens/Create
        public IActionResult Create()
        {
            ViewData["ChefID"] = new SelectList(_context.Chef, "Id", "Id");
            ViewData["UtensilID"] = new SelectList(_context.Utensil, "Id", "Id");
            ViewData["LocationID"] = new SelectList(_context.Location, "Id", "Id");
            return View();
        }

        // POST: Kitchens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Temperature,Setting,ChefID,UtensilID")] Kitchen kitchen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kitchen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChefID"] = new SelectList(_context.Chef, "Id", "Id", kitchen.ChefID);
            ViewData["UtensilID"] = new SelectList(_context.Utensil, "Id", "Id", kitchen.UtensilID);
            ViewData["LocationID"] = new SelectList(_context.Location, "Id", "Id", kitchen.LocationID);
            return View(kitchen);
        }

        // GET: Kitchens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitchen = await _context.Kitchen.FindAsync(id);
            if (kitchen == null)
            {
                return NotFound();
            }
            ViewData["ChefID"] = new SelectList(_context.Chef, "Id", "Id", kitchen.ChefID);
            ViewData["UtensilID"] = new SelectList(_context.Utensil, "Id", "Id", kitchen.UtensilID);
            ViewData["LocationID"] = new SelectList(_context.Location, "Id", "Id", kitchen.LocationID);
            return View(kitchen);
        }

        // POST: Kitchens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Temperature,Setting,ChefID,UtensilID,LocationID")] Kitchen kitchen)
        {
            if (id != kitchen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kitchen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitchenExists(kitchen.Id))
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
            ViewData["ChefID"] = new SelectList(_context.Chef, "Id", "Id", kitchen.ChefID);
            ViewData["UtensilID"] = new SelectList(_context.Utensil, "Id", "Id", kitchen.UtensilID);
            ViewData["LocationID"] = new SelectList(_context.Location, "Id", "Id", kitchen.LocationID);
            return View(kitchen);
        }

        // GET: Kitchens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitchen = await _context.Kitchen
                .Include(k => k.Chef)
                .Include(k => k.Utensil)
                .Include(k => k.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kitchen == null)
            {
                return NotFound();
            }

            return View(kitchen);
        }

        // POST: Kitchens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kitchen = await _context.Kitchen.FindAsync(id);
            if (kitchen != null)
            {
                _context.Kitchen.Remove(kitchen);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KitchenExists(int id)
        {
            return _context.Kitchen.Any(e => e.Id == id);
        }
    }
}
