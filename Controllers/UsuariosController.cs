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
    public class UsuariosController : Controller
    {
        private readonly BeachSysContext _context;

        public UsuariosController(BeachSysContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var beachSysContext = _context.Usuario.Include(u => u.Compartimento);
            return View(await beachSysContext.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.Compartimento)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["CompartimentoId"] = new SelectList(_context.Compartimento, "CompartimentoId", "CompartimentoId");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,Email,Cpf,Nome,CompartimentoId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if(await _context.Usuario.FirstOrDefaultAsync(m => m.Cpf == usuario.Cpf)!=null){
                    ModelState.AddModelError("Cpf", "O CPF digitado já existe no nosso cadastro.");
                    return View(usuario);
                }
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompartimentoId"] = new SelectList(_context.Compartimento, "CompartimentoId", "Tamanho", usuario.CompartimentoId);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["CompartimentoId"] = new SelectList(_context.Compartimento, "CompartimentoId", "CompartimentoId", usuario.CompartimentoId);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,Email,Cpf,Nome,CompartimentoId")] Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.UsuarioId))
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
            ViewData["CompartimentoId"] = new SelectList(_context.Compartimento, "CompartimentoId", "Tamanho", usuario.CompartimentoId);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.Compartimento)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if(usuario.CompartimentoId!=null){
                var compartimento = await _context.Compartimento.FindAsync(id);
                compartimento.Disponivel = true;
                compartimento.Aberto = true;
                _context.Compartimento.Update(compartimento);
            }
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.UsuarioId == id);
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser([Bind("UsuarioId,Email,Cpf,Nome,CompartimentoId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if(await _context.Usuario.FirstOrDefaultAsync(m => m.Cpf == usuario.Cpf)!=null){
                    ModelState.AddModelError("Cpf", "O CPF digitado já existe no nosso cadastro.");
                    return View(usuario);
                }
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("IndexUser","Armarios",new { id = usuario.UsuarioId });
            }
            return View(usuario);
        }
    }
}
