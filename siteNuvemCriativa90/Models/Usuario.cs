using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace siteNuvemCriativa90.Models
{
    public class Usuario
    {
        [Key]
        public int IDUsuario { get; set; }
        [StringLength(50, ErrorMessage = "Somente 50 caracteres")]
        [Required]
        public string Login { get; set; }
        [StringLength(50, ErrorMessage = "Somente 50 caracteres")]
        [Required]
        public string Senha { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Cadastro")]
        public DateTime DataCadastro { get; set; }
        [StringLength(1)]
        [Required]
        public string Apagado { get; set; }
        [Display(Name = "Grupo Usuário")]
        public int IDGrupoUsuario { get; set; }
        [ForeignKey("IDGrupoUsuario")]
        [Display(Name = "Grupo Usuário")]
        public GrupoUsuario GrupoUsuario { get; set; }
     
    }
}
