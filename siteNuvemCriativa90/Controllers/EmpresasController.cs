using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using siteNuvemCriativa90.Data;
using siteNuvemCriativa90.Models;

namespace siteNuvemCriativa90.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly siteNuvemCriativa90DBContext _context;

        public EmpresasController(siteNuvemCriativa90DBContext context)
        {
            _context = context;
        }
        // GET: Empresas
        public async Task<IActionResult> Index()
        {
            var siteNuvemCriativa90DBContext = _context.Empresas.Include(e => e.Endereco).Include(e => e.GrupoUsuario).Where(u => u.Apagado == "N");
            return View(await siteNuvemCriativa90DBContext.ToListAsync());
        }

        // GET: Empresas/Details/5
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas
                .Include(e => e.Endereco)
                .Include(e => e.GrupoUsuario)
                .FirstOrDefaultAsync(m => m.IDEmpresa == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }
        public IActionResult Cadastrar()
        {
            ViewData["IDEndereco"] = new SelectList(_context.Enderecos, "IDEndereco", "Logradouro");
            ViewData["IDGrupoUsuario"] = new SelectList(_context.GrupoUsuarios, "IDGrupoUsuario", "TipoUsuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar([Bind("IDEmpresa,Login,Senha,CNPJ,RazaoSocial,NomeFantasia,Email,Telefone,Necessidade,Ramo,DataCadastro,Apagado,IDEndereco,IDGrupoUsuario")] Empresa empresa)
        {
            try
            {
                empresa.Apagado = "N";
                empresa.DataCadastro = DateTime.Now;
                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewData["IDEndereco"] = new SelectList(_context.Enderecos, "IDEndereco", "Logradouro", empresa.IDEndereco);
                ViewData["IDGrupoUsuario"] = new SelectList(_context.GrupoUsuarios, "IDGrupoUsuario", "TipoUsuario", empresa.IDGrupoUsuario);
                return View(empresa);
            }

        }




        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }
            ViewData["IDEndereco"] = new SelectList(_context.Enderecos, "IDEndereco", "Logradouro", empresa.IDEndereco);
            ViewData["IDGrupoUsuario"] = new SelectList(_context.GrupoUsuarios, "IDGrupoUsuario", "TipoUsuario", empresa.IDGrupoUsuario);
            return View(empresa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IDEmpresa,Login,Senha,CNPJ,RazaoSocial,NomeFantasia,Email,Telefone, Necessidade,Ramo,DataCadastro,Apagado,IDEndereco,IDGrupoUsuario")] Empresa empresa)
        {
            if (id != empresa.IDEmpresa)
            {
                return NotFound();
            }
            try
            {
                empresa.Apagado = "N";
                _context.Update(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaExists(empresa.IDEmpresa))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas
               .Include(e => e.Endereco)
               .Include(e => e.GrupoUsuario)
               .FirstOrDefaultAsync(m => m.IDEmpresa == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmacaoExcluir(int id, [Bind("IDEmpresa,Login,Senha,CNPJ,RazaoSocial,NomeFantasia,Email,Telefone,Necessidade,Ramo,DataCadastro,Apagado,IDEndereco,IDGrupoUsuario")] Empresa empresa)
        {
            if (id != empresa.IDEmpresa)
            {
                return NotFound();
            }
            try
            {
                empresa.Apagado = "S";
                _context.Update(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaExists(empresa.IDEmpresa))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool EmpresaExists(int id)
        {
            return _context.Empresas.Any(e => e.IDEmpresa == id);
        }
    }
}
