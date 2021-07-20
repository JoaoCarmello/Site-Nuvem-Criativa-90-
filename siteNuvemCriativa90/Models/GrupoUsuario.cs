using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace siteNuvemCriativa90.Models
{
    public class GrupoUsuario
    {
        [Key]
        public int IDGrupoUsuario { get; set; }
        [StringLength(25, ErrorMessage = "Somente 25 caracteres")]
        [Required]
        [Display(Name = "Tipo Usuário")]
        public string TipoUsuario { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Cadastro")]
        public DateTime DataCadastro { get; set; }
        [StringLength(1)]
        [Required]
        public string Apagado { get; set; }

    }
}