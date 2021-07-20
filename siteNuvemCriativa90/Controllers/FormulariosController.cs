using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using siteNuvemCriativa90.Data;
using siteNuvemCriativa90.Models;

namespace siteNuvemCriativa90.Controllers
{
    public class FormulariosController : Controller
    {
        private readonly siteNuvemCriativa90DBContext _context;

        public FormulariosController(siteNuvemCriativa90DBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Relatorio_de_Formulario()
        {
            return new ViewAsPdf(await _context.Formularios.ToListAsync());
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Formularios.ToListAsync());
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulario = await _context.Formularios
                .FirstOrDefaultAsync(m => m.IDFormulario == id);
            if (formulario == null)
            {
                return NotFound();
            }

            return View(formulario);
        }

        public async Task<IActionResult> Verificado(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulario = await _context.Formularios.FindAsync(id);
            if (formulario == null)
            {
                return NotFound();
            }
            return View(formulario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Verificado(int id, [Bind("IDFormulario,Nome,Sobrenome,Email,Telefone,Necessidade,Ramo,Verificado,DataCadastro,Apagado")] Formulario formulario)
        {
            if (id != formulario.IDFormulario)
            {
                return NotFound();
            }
            try
            {
                formulario.Apagado = "N";
                _context.Update(formulario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormularioExists(formulario.IDFormulario))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
         
        }
        private bool FormularioExists(int id)
        {
            return _context.Formularios.Any(e => e.IDFormulario == id);
        }
    }
}
