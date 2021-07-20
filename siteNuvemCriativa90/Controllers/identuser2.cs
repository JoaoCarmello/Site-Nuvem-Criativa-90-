using Microsoft.AspNetCore.Identity;
using siteNuvemCriativa90.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace siteNuvemCriativa90.Controllers
{
    public class identuser2 : IdentityUser
    {
        public int IDGrupoUsuario { get; set; }
        [ForeignKey("IDGrupoUsuario")]
        [Display(Name = "Grupo Usuário")]
        public GrupoUsuario GrupoUsuario { get; set; }
    }
}
