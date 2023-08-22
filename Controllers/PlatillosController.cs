using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurante_API.Data;
using Restaurante_API.Models;

namespace Restaurante_API.Controllers
{
    public class PlatillosController : Controller
    {
        private readonly RestauranteContext _context;

        public PlatillosController(RestauranteContext context)
        {
            _context = context;
        }

        // GET: Platillos
        public async Task<IActionResult> Index()
        {
              return _context.Platillo != null ? 
                          View(await _context.Platillo.ToListAsync()) :
                          Problem("Entity set 'RestauranteContext.Platillo'  is null.");
        }

        // GET: Platillos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Platillo == null)
            {
                return NotFound();
            }

            var platillo = await _context.Platillo
                .FirstOrDefaultAsync(m => m.platillo_id == id);
            if (platillo == null)
            {
                return NotFound();
            }

            return View(platillo);
        }

        // GET: Platillos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Platillos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("platillo_id,restaurante_id,nombre,descripcion,precio,vegano,gluten,cantidad")] Platillo platillo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(platillo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(platillo);
        }

        // GET: Platillos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Platillo == null)
            {
                return NotFound();
            }

            var platillo = await _context.Platillo.FindAsync(id);
            if (platillo == null)
            {
                return NotFound();
            }
            return View(platillo);
        }

        // POST: Platillos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("platillo_id,restaurante_id,nombre,descripcion,precio,vegano,gluten,cantidad")] Platillo platillo)
        {
            if (id != platillo.platillo_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(platillo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlatilloExists(platillo.platillo_id))
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
            return View(platillo);
        }

        // GET: Platillos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Platillo == null)
            {
                return NotFound();
            }

            var platillo = await _context.Platillo
                .FirstOrDefaultAsync(m => m.platillo_id == id);
            if (platillo == null)
            {
                return NotFound();
            }

            return View(platillo);
        }

        // POST: Platillos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Platillo == null)
            {
                return Problem("Entity set 'RestauranteContext.Platillo'  is null.");
            }
            var platillo = await _context.Platillo.FindAsync(id);
            if (platillo != null)
            {
                _context.Platillo.Remove(platillo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlatilloExists(int id)
        {
          return (_context.Platillo?.Any(e => e.platillo_id == id)).GetValueOrDefault();
        }
    }
}
