using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace siteNuvemCriativa90.Models
{
    public class Permissoes
    {   [Key]
        public int IDPermissao { get; set; }
     
        [StringLength(1)]
        [Required]
        [Display(Name = "Consultar")]
        public string ConsultaModulo { get; set; }
        [StringLength(1)]
        [Required]
        [Display(Name = "Cadastrar")]
        public string CadastraModulo { get; set; }
        [StringLength(1)]
        [Required]
        [Display(Name = "Alterar")]
        public string AlteraModulo { get; set; }
        [StringLength(1)]
        [Required]
        [Display(Name = "Excluir")]
        public string ExcluiModulo { get; set; }
        [StringLength(1)]
        [Required]
        [Display(Name = "Relatorio")]
        public string RelatorioModulo { get; set; }
        [Display(Name = "Grupo Usuário")]
        public int IDGrupoUsuario { get; set; }
        [ForeignKey("IDGrupoUsuario")]
        public GrupoUsuario GrupoUsuario { get; set; }
    }
}
