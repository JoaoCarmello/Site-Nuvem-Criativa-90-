using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace siteNuvemCriativa90.Models

{
    public class Formulario
    {
        [Key]
        public int IDFormulario { get; set; }
        [StringLength(50, ErrorMessage = "Somente 50 caracteres")]
        [Required]
        public string Nome { get; set; }
        [StringLength(50, ErrorMessage = "Somente 50 caracteres")]
        [Required]
        public string Sobrenome { get; set; }
        [StringLength(50, ErrorMessage = "Somente 50 caracteres")]
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [StringLength(17, ErrorMessage = "Somente 17 caracteres")]
        [Required]
        public string Telefone { get; set; }
        [StringLength(200, ErrorMessage = "Somente 200 caracteres")]
        [Required]
        public string Necessidade { get; set; }
        [StringLength(50, ErrorMessage = "Somente 50 caracteres")]
        [Required]
        public string Ramo { get; set; }
        [StringLength(1, ErrorMessage = "Somente 1 caracter")]
        [Required]
        public string Verificado { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Cadastro")]
        public DateTime DataCadastro { get; set; }
        [StringLength(1, ErrorMessage = "Somente 1 caracter")]
        [Required]
        public string Apagado { get; set; }
    }
}
