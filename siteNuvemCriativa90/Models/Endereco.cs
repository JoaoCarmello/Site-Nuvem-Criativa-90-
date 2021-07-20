using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace siteNuvemCriativa90.Models
{
    public class Endereco
    {
        [Key]
        public int IDEndereco { get; set; }
        [StringLength(50, ErrorMessage = "Somente 50 caracteres")]
        [Required]
        public string Cidade { get; set; }
        [StringLength(2, ErrorMessage = "Somente 2 caracteres")]
        [Required]
        public string UF{ get; set; }
        [StringLength(50, ErrorMessage = "Somente 50 caracteres")]
        [Required]
        public string Logradouro { get; set; }
        [StringLength(7, ErrorMessage = "Somente 7 caracteres")]
        [Required]
        [Display(Name = "Número")]
        public string Numero { get; set; }
        [StringLength(1)]
        [Required]
        public string Apagado { get; set; }

       
    }
}