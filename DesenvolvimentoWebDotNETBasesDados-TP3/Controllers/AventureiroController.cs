using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesenvolvimentoWebDotNETBasesDados_TP3.Data;
using DesenvolvimentoWebDotNETBasesDados_TP3.Models;

namespace DesenvolvimentoWebDotNETBasesDados_TP3.Controllers
{
    public class AventureiroController : Controller
    {
        private readonly AventureiroContext _context;

        public AventureiroController(AventureiroContext context)
        {
            _context = context;
        }

        // GET: Aventureiro
        public async Task<IActionResult> Index()
        {
              return _context.Aventureiros != null ? 
                          View(await _context.Aventureiros.ToListAsync()) :
                          Problem("Entity set 'AventureiroContext.Aventureiros'  is null.");
        }

        // GET: Aventureiro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Aventureiros == null)
            {
                return NotFound();
            }

            var aventureiro = await _context.Aventureiros
                .FirstOrDefaultAsync(m => m.AventureiroID == id);
            if (aventureiro == null)
            {
                return NotFound();
            }

            return View(aventureiro);
        }

        // GET: Aventureiro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aventureiro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AventureiroID,Nome,Sobrenome,DataNascimento")] Aventureiro aventureiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aventureiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aventureiro);
        }

        // GET: Aventureiro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Aventureiros == null)
            {
                return NotFound();
            }

            var aventureiro = await _context.Aventureiros.FindAsync(id);
            if (aventureiro == null)
            {
                return NotFound();
            }
            return View(aventureiro);
        }

        // POST: Aventureiro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AventureiroID,Nome,Sobrenome,DataNascimento")] Aventureiro aventureiro)
        {
            if (id != aventureiro.AventureiroID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aventureiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AventureiroExists(aventureiro.AventureiroID))
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
            return View(aventureiro);
        }

        // GET: Aventureiro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Aventureiros == null)
            {
                return NotFound();
            }

            var aventureiro = await _context.Aventureiros
                .FirstOrDefaultAsync(m => m.AventureiroID == id);
            if (aventureiro == null)
            {
                return NotFound();
            }

            return View(aventureiro);
        }

        // POST: Aventureiro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Aventureiros == null)
            {
                return Problem("Entity set 'AventureiroContext.Aventureiros'  is null.");
            }
            var aventureiro = await _context.Aventureiros.FindAsync(id);
            if (aventureiro != null)
            {
                _context.Aventureiros.Remove(aventureiro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AventureiroExists(int id)
        {
          return (_context.Aventureiros?.Any(e => e.AventureiroID == id)).GetValueOrDefault();
        }
    }
}
