using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using siteNuvemCriativa90.Data;
using siteNuvemCriativa90.Models;

namespace siteNuvemCriativa90.Controllers
{
    public class GrupoUsuariosController : Controller
    {
        private readonly siteNuvemCriativa90DBContext _context;

        public GrupoUsuariosController(siteNuvemCriativa90DBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Relatorio_de_GrupoUsuarios()
        {
            return new ViewAsPdf(await _context.GrupoUsuarios.ToListAsync());
        }
     
        public async Task<IActionResult> Index()
        {
            return View(await _context.GrupoUsuarios.ToListAsync()) ;
        }
    }
}
