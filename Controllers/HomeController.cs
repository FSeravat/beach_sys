using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using beach_sys.Models;

using Microsoft.EntityFrameworkCore;

namespace beach_sys.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly BeachSysContext _context;

        public HomeController(ILogger<HomeController> logger, BeachSysContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string Cpf)
        {   
            var usuario = await _context.Usuario.FirstOrDefaultAsync(m => m.Cpf == Cpf);
            if(usuario==null){
                ModelState.AddModelError("Cpf", "O CPF digitado não foi encontrado.");
                return View();
            }
            return RedirectToAction("IndexUser","Armarios",new { id = usuario.UsuarioId });
        }

        public IActionResult Admin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
