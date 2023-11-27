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
    public class InvestiduraController : Controller
    {
        private readonly AventureiroContext _context;

        public InvestiduraController(AventureiroContext context)
        {
            _context = context;
        }

        // GET: Investidura
        public async Task<IActionResult> Index()
        {
            var aventureiroContext = _context.Investiduras.Include(i => i.Aventureiro).Include(i => i.Especialidade);
            return View(await aventureiroContext.ToListAsync());
        }

        // GET: Investidura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Investiduras == null)
            {
                return NotFound();
            }

            var investidura = await _context.Investiduras
                .Include(i => i.Aventureiro)
                .Include(i => i.Especialidade)
                .FirstOrDefaultAsync(m => m.InvestiduraID == id);
            if (investidura == null)
            {
                return NotFound();
            }

            return View(investidura);
        }

        // GET: Investidura/Create
        public IActionResult Create()
        {
            ViewData["AventureiroID"] = new SelectList(_context.Aventureiros, "AventureiroID", "AventureiroID");
            ViewData["EspecialidadeID"] = new SelectList(_context.Especialidades, "EspecialidadeID", "EspecialidadeID");
            return View();
        }

        // POST: Investidura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvestiduraID,AventureiroID,EspecialidadeID,DataInvestidura")] Investidura investidura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(investidura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AventureiroID"] = new SelectList(_context.Aventureiros, "AventureiroID", "AventureiroID", investidura.AventureiroID);
            ViewData["EspecialidadeID"] = new SelectList(_context.Especialidades, "EspecialidadeID", "EspecialidadeID", investidura.EspecialidadeID);
            return View(investidura);
        }

        // GET: Investidura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Investiduras == null)
            {
                return NotFound();
            }

            var investidura = await _context.Investiduras.FindAsync(id);
            if (investidura == null)
            {
                return NotFound();
            }
            ViewData["AventureiroID"] = new SelectList(_context.Aventureiros, "AventureiroID", "AventureiroID", investidura.AventureiroID);
            ViewData["EspecialidadeID"] = new SelectList(_context.Especialidades, "EspecialidadeID", "EspecialidadeID", investidura.EspecialidadeID);
            return View(investidura);
        }

        // POST: Investidura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvestiduraID,AventureiroID,EspecialidadeID,DataInvestidura")] Investidura investidura)
        {
            if (id != investidura.InvestiduraID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(investidura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvestiduraExists(investidura.InvestiduraID))
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
            ViewData["AventureiroID"] = new SelectList(_context.Aventureiros, "AventureiroID", "AventureiroID", investidura.AventureiroID);
            ViewData["EspecialidadeID"] = new SelectList(_context.Especialidades, "EspecialidadeID", "EspecialidadeID", investidura.EspecialidadeID);
            return View(investidura);
        }

        // GET: Investidura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Investiduras == null)
            {
                return NotFound();
            }

            var investidura = await _context.Investiduras
                .Include(i => i.Aventureiro)
                .Include(i => i.Especialidade)
                .FirstOrDefaultAsync(m => m.InvestiduraID == id);
            if (investidura == null)
            {
                return NotFound();
            }

            return View(investidura);
        }

        // POST: Investidura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Investiduras == null)
            {
                return Problem("Entity set 'AventureiroContext.Investiduras'  is null.");
            }
            var investidura = await _context.Investiduras.FindAsync(id);
            if (investidura != null)
            {
                _context.Investiduras.Remove(investidura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvestiduraExists(int id)
        {
          return _context.Investiduras.Any(e => e.InvestiduraID == id);
        }
    }
}
