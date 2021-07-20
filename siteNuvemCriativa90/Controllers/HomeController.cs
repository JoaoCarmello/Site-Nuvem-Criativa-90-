using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using siteNuvemCriativa90.Data;
using siteNuvemCriativa90.Models;

namespace siteNuvemCriativa90.Controllers
{
    public class HomeController : Controller
    {
        private readonly siteNuvemCriativa90DBContext _context;

        public HomeController(siteNuvemCriativa90DBContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDFormulario,Nome,Sobrenome,Email,Telefone,Necessidade,Ramo")] Formulario formulario)
        {
            try
            {
                formulario.Verificado = "N";
                formulario.DataCadastro = DateTime.Now;
                formulario.Apagado = "N";
                _context.Add(formulario);
                 _context.SaveChanges();
                 await Response.WriteAsync("<script>location.href='Index'; alert('Sua mensagem foi enviada com sucesso!!'); </script>");
                 return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                await Response.WriteAsync("<script>alert('Erro, tente novamente!');</script>");
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    
    }
}
