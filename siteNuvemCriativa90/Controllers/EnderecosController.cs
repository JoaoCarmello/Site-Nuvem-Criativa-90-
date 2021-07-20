using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using siteNuvemCriativa90.Models;
using System.IO;
using siteNuvemCriativa90.Data;
using Rotativa.AspNetCore;

namespace siteNuvemCriativa90.Controllers
{
    public class EnderecosController : Controller
    {
           private readonly siteNuvemCriativa90DBContext _context;

        public EnderecosController(siteNuvemCriativa90DBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Relatorio_de_Endereco()
        {
            var siteNuvemCriativa90DBContext = _context.Enderecos.ToList().Where(grupo => grupo.Apagado == "N");
            return new ViewAsPdf(siteNuvemCriativa90DBContext.ToList());
        }
        public async Task<IActionResult> Index()
        {
            var siteNuvemCriativa90DBContext = _context.Enderecos.ToList().Where(grupo => grupo.Apagado == "N");
            return View(siteNuvemCriativa90DBContext.ToList());
        }
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _context.Enderecos
                .FirstOrDefaultAsync(m => m.IDEndereco == id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar([Bind("IDEndereco,Cidade,UF,Logradouro,Numero,Apagado")] Endereco endereco)
        {
            try
            {
                endereco.Apagado = "N";
                _context.Add(endereco);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {

                return RedirectToAction(nameof(Index));
            }

        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }
            return View(endereco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IDEndereco,Cidade,UF,Logradouro,Numero,Apagado")] Endereco endereco)
        {
            if (id != endereco.IDEndereco)
            {
                return NotFound();
            }

            try
            {
                endereco.Apagado = "N";
                 _context.Update(endereco);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoExists(endereco.IDEndereco))
                {
                    return NotFound();
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
        }

        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _context.Enderecos
                .FirstOrDefaultAsync(m => m.IDEndereco == id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmacaoExcluir(int id, [Bind("IDEndereco,Cidade,UF,Logradouro,Numero,Apagado")] Endereco endereco)
        {
            if (id != endereco.IDEndereco)
            {
                return NotFound();
            }
            try
            {
                endereco.Apagado = "S";
                _context.Update(endereco);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoExists(endereco.IDEndereco))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
        }
        private bool EnderecoExists(int id)
        {
            return _context.Enderecos.Any(e => e.IDEndereco == id);
        }

    }
}

