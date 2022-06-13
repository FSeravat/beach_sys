using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using beach_sys.Models;

namespace beach_sys.Controllers
{
    public class CompartimentosController : Controller
    {
        private readonly BeachSysContext _context;

        public CompartimentosController(BeachSysContext context)
        {
            _context = context;
        }

        // GET: Compartimentos
        public async Task<IActionResult> Index()
        {
            var beachSysContext = _context.Compartimento.Include(c => c.Armario);
            return View(await beachSysContext.ToListAsync());
        }

        public async Task<IActionResult> IndexUser(int id, int secondId)
        {
            var armario = await _context.Armario.FindAsync(id);
            ViewData["Armario"] = armario.Nome;
            var beachSysContext = _context.Compartimento.Include(c => c.Armario);
            var beachSysContext1 = beachSysContext.Where(c => c.ArmarioId == secondId);
            beachSysContext1 = beachSysContext1.Where(c => c.Disponivel);
            return View(await beachSysContext1.ToListAsync());
        }

        // GET: Compartimentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compartimento = await _context.Compartimento
                .Include(c => c.Armario)
                .FirstOrDefaultAsync(m => m.CompartimentoId == id);
            if (compartimento == null)
            {
                return NotFound();
            }

            return View(compartimento);
        }

        // GET: Compartimentos/Create
        public IActionResult Create()
        {
            ViewData["ArmarioId"] = new SelectList(_context.Armario, "ArmarioId", "Nome");
            return View();
        }

        // POST: Compartimentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompartimentoId,Numero,Tamanho,Disponivel,ArmarioId")] Compartimento compartimento)
        {
            if (ModelState.IsValid)
            {
                compartimento.Disponivel=true;
                _context.Add(compartimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArmarioId"] = new SelectList(_context.Armario, "ArmarioId", "Nome", compartimento.ArmarioId);
            return View(compartimento);
        }

        // GET: Compartimentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compartimento = await _context.Compartimento.FindAsync(id);
            if (compartimento == null)
            {
                return NotFound();
            }
            ViewData["ArmarioId"] = new SelectList(_context.Armario, "ArmarioId", "Nome", compartimento.ArmarioId);
            return View(compartimento);
        }

        // POST: Compartimentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompartimentoId,Numero,Tamanho,Disponivel,ArmarioId")] Compartimento compartimento)
        {
            if (id != compartimento.CompartimentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compartimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompartimentoExists(compartimento.CompartimentoId))
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
            ViewData["ArmarioId"] = new SelectList(_context.Armario, "ArmarioId", "Nome", compartimento.ArmarioId);
            return View(compartimento);
        }

        // GET: Compartimentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compartimento = await _context.Compartimento
                .Include(c => c.Armario)
                .FirstOrDefaultAsync(m => m.CompartimentoId == id);
            if (compartimento == null)
            {
                return NotFound();
            }

            return View(compartimento);
        }

        // POST: Compartimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compartimento = await _context.Compartimento.FindAsync(id);
            _context.Compartimento.Remove(compartimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompartimentoExists(int id)
        {
            return _context.Compartimento.Any(e => e.CompartimentoId == id);
        }
    }
}
