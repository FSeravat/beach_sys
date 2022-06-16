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

        public async Task<IActionResult> Index()
        {
            if(!_context.Armario.Any()){
                _context.Armario.Add(new Armario{ArmarioId=1,Nome="Pituba",Latitude=-13.0022854,Longitude=-38.4639479});
                _context.Compartimento.Add(new Compartimento{CompartimentoId=1,Numero=1,Tamanho="50x50x50 cm",Aberto=true,Disponivel=true,ArmarioId=1});
                _context.Compartimento.Add(new Compartimento{CompartimentoId=2,Numero=2,Tamanho="50x50x50 cm",Aberto=true,Disponivel=true,ArmarioId=1});
                _context.Compartimento.Add(new Compartimento{CompartimentoId=3,Numero=3,Tamanho="50x50x50 cm",Aberto=true,Disponivel=true,ArmarioId=1});
                _context.Compartimento.Add(new Compartimento{CompartimentoId=4,Numero=4,Tamanho="50x50x50 cm",Aberto=true,Disponivel=true,ArmarioId=1});
                _context.Compartimento.Add(new Compartimento{CompartimentoId=5,Numero=5,Tamanho="50x50x50 cm",Aberto=true,Disponivel=true,ArmarioId=1});
                _context.Compartimento.Add(new Compartimento{CompartimentoId=6,Numero=6,Tamanho="50x50x50 cm",Aberto=true,Disponivel=true,ArmarioId=1});
                _context.Armario.Add(new Armario{ArmarioId=2,Nome="Barra",Latitude=13.0101583,Longitude=-38.5329386});
                _context.Compartimento.Add(new Compartimento{CompartimentoId=7,Numero=1,Tamanho="100x50x50 cm",Aberto=true,Disponivel=true,ArmarioId=2});
                _context.Compartimento.Add(new Compartimento{CompartimentoId=8,Numero=2,Tamanho="100x50x50 cm",Aberto=true,Disponivel=true,ArmarioId=2});
                _context.Compartimento.Add(new Compartimento{CompartimentoId=9,Numero=3,Tamanho="100x50x50 cm",Aberto=true,Disponivel=true,ArmarioId=2});
                _context.Compartimento.Add(new Compartimento{CompartimentoId=10,Numero=4,Tamanho="100x50x50 cm",Aberto=true,Disponivel=true,ArmarioId=2});
                _context.Compartimento.Add(new Compartimento{CompartimentoId=11,Numero=5,Tamanho="100x50x50 cm",Aberto=true,Disponivel=true,ArmarioId=2});
                _context.Compartimento.Add(new Compartimento{CompartimentoId=12,Numero=6,Tamanho="100x50x50 cm",Aberto=true,Disponivel=true,ArmarioId=2});
                _context.Armario.Add(new Armario{ArmarioId=3,Nome="Rio Vermelho",Latitude=-13.011384,Longitude=-38.4940763});
                _context.Compartimento.Add(new Compartimento{CompartimentoId=13,Numero=1,Tamanho="50x50x50 cm",Aberto=true,Disponivel=true,ArmarioId=3});
                _context.Compartimento.Add(new Compartimento{CompartimentoId=14,Numero=2,Tamanho="50x50x50 cm",Aberto=true,Disponivel=true,ArmarioId=3});
                _context.Compartimento.Add(new Compartimento{CompartimentoId=15,Numero=3,Tamanho="50x50x50 cm",Aberto=true,Disponivel=true,ArmarioId=3});
                _context.Compartimento.Add(new Compartimento{CompartimentoId=16,Numero=4,Tamanho="50x50x50 cm",Aberto=true,Disponivel=true,ArmarioId=3});
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
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
