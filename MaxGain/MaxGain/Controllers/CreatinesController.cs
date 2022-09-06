using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MaxGain.Data;
using MaxGain.Models;

namespace MaxGain.Controllers
{
    public class CreatinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CreatinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Creatines
        public async Task<IActionResult> Index()
        {
              return _context.Creatine != null ? 
                          View(await _context.Creatine.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Creatine'  is null.");
        }

        // GET: Creatines/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Creatine == null)
            {
                return NotFound();
            }

            var creatine = await _context.Creatine
                .FirstOrDefaultAsync(m => m.Id == id);
            if (creatine == null)
            {
                return NotFound();
            }

            return View(creatine);
        }

        // GET: Creatines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Creatines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price")] Creatine creatine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(creatine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(creatine);
        }

        // GET: Creatines/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Creatine == null)
            {
                return NotFound();
            }

            var creatine = await _context.Creatine.FindAsync(id);
            if (creatine == null)
            {
                return NotFound();
            }
            return View(creatine);
        }

        // POST: Creatines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Price")] Creatine creatine)
        {
            if (id != creatine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(creatine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreatineExists(creatine.Id))
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
            return View(creatine);
        }

        // GET: Creatines/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Creatine == null)
            {
                return NotFound();
            }

            var creatine = await _context.Creatine
                .FirstOrDefaultAsync(m => m.Id == id);
            if (creatine == null)
            {
                return NotFound();
            }

            return View(creatine);
        }

        // POST: Creatines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Creatine == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Creatine'  is null.");
            }
            var creatine = await _context.Creatine.FindAsync(id);
            if (creatine != null)
            {
                _context.Creatine.Remove(creatine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreatineExists(string id)
        {
          return (_context.Creatine?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
