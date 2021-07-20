using System;
using System.Collections.Generic;
using System.Linq;
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
    public class UsuariosController : Controller
    {
        private readonly siteNuvemCriativa90DBContext _context;

        public UsuariosController(siteNuvemCriativa90DBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Relatorio_de_Usuario()
        {
            var siteNuvemCriativa90DBContext = _context.Usuarios.Include(u => u.GrupoUsuario).Where(grupo => grupo.Apagado == "N");
            return new ViewAsPdf(await siteNuvemCriativa90DBContext.ToListAsync());
        }
        public async Task<IActionResult> Index()
        {
            var siteNuvemCriativa90DBContext = _context.Usuarios.Include(u => u.GrupoUsuario).Where(grupo => grupo.Apagado == "N");
            return View(await siteNuvemCriativa90DBContext.ToListAsync());
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.GrupoUsuario)
                .FirstOrDefaultAsync(m => m.IDUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        public IActionResult Cadastrar()
        {
            ViewData["IDGrupoUsuario"] = new SelectList(_context.GrupoUsuarios, "IDGrupoUsuario", "TipoUsuario");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar([Bind("IDUsuario,Login,Senha,DataCadastro,Apagado,IDGrupoUsuario")] Usuario usuario)
        {
            try
            {
                usuario.Apagado = "N";
                usuario.DataCadastro = DateTime.Now;
                _context.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ViewData["IDGrupoUsuario"] = new SelectList(_context.GrupoUsuarios, "IDGrupoUsuario", "TipoUsuario", usuario.IDGrupoUsuario);
                return View(usuario);
            }

        }
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["IDGrupoUsuario"] = new SelectList(_context.GrupoUsuarios, "IDGrupoUsuario", "TipoUsuario", usuario.IDGrupoUsuario);
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IDUsuario,Login,Senha,DataCadastro,Apagado,IDGrupoUsuario")] Usuario usuario)
        {
            if (id != usuario.IDUsuario)
            {
                return NotFound();
            }
            try
            {
                usuario.Apagado = "N";
                _context.Update(usuario);
                _context.SaveChangesAsync();
                ViewData["IDGrupoUsuario"] = new SelectList(_context.GrupoUsuarios, "IDGrupoUsuario", "TipoUsuario", usuario.IDGrupoUsuario);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(usuario.IDUsuario))
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

            var usuario = await _context.Usuarios
                .Include(u => u.GrupoUsuario)
                .FirstOrDefaultAsync(m => m.IDUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmacaoExcluir(int id, [Bind("IDUsuario,Login,Senha,DataCadastro,Apagado,IDGrupoUsuario")] Usuario usuario)
        {
            if (id != usuario.IDUsuario)
            {
                return NotFound();
            }
            try
            {
                usuario.Apagado = "S";
                _context.Update(usuario);
                await _context.SaveChangesAsync();
                ViewData["IDGrupoUsuario"] = new SelectList(_context.GrupoUsuarios, "IDGrupoUsuario", "IDGrupoUsuario", usuario.IDGrupoUsuario);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(usuario.IDUsuario))
                {
                    return NotFound();
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }

        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IDUsuario == id);
        }
    }
}
