using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MaxGain.Data;
using MaxGain.Models;
using Microsoft.AspNetCore.Authorization;

namespace MaxGain.Controllers
{
    public class ProteinsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProteinsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Proteins
        public async Task<IActionResult> Index()
        {
              return _context.Protein != null ? 
                          View(await _context.Protein.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Protein'  is null.");
        }

        // GET: Proteins/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Protein == null)
            {
                return NotFound();
            }

            var protein = await _context.Protein
                .FirstOrDefaultAsync(m => m.Id == id);
            if (protein == null)
            {
                return NotFound();
            }

            return View(protein);
        }

        // GET: Proteins/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proteins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price")] Protein protein)
        {
            if (ModelState.IsValid)
            {
                _context.Add(protein);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(protein);
        }

        // GET: Proteins/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Protein == null)
            {
                return NotFound();
            }

            var protein = await _context.Protein.FindAsync(id);
            if (protein == null)
            {
                return NotFound();
            }
            return View(protein);
        }

        // POST: Proteins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Price")] Protein protein)
        {
            if (id != protein.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(protein);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProteinExists(protein.Id))
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
            return View(protein);
        }

        // GET: Proteins/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Protein == null)
            {
                return NotFound();
            }

            var protein = await _context.Protein
                .FirstOrDefaultAsync(m => m.Id == id);
            if (protein == null)
            {
                return NotFound();
            }

            return View(protein);
        }

        // POST: Proteins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Protein == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Protein'  is null.");
            }
            var protein = await _context.Protein.FindAsync(id);
            if (protein != null)
            {
                _context.Protein.Remove(protein);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProteinExists(string id)
        {
          return (_context.Protein?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
