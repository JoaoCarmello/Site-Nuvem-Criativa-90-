using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace siteNuvemCriativa90.Models
{
    public class Portfolio
    {   [Key]
        public int IDPortfolio { get; set; }
        [StringLength(50, ErrorMessage = "Somente 50 caracteres")]
        [Required]
        [Display(Name = "Descrição Portfolio")]
        public string DescricaoPortfolio { get; set; }
        [StringLength(100, ErrorMessage = "Somente 100 caracteres")]
        [Display(Name = "Observação")]
        public string Observacao { get; set; }
        [StringLength(50, ErrorMessage = "Somente 50 caracteres")]
        [Required]
        [Display(Name = "Tipo Portfolio")]
        public string TipoPortfolio { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Cadastro")]
        public DateTime DataCadastro { get; set; }
        [StringLength(1)]
        [Required]
        public string Apagado { get; set; }
        [Display(Name = "Empresa")]
        public int IDEmpresa { get; set; }
        [ForeignKey("IDEmpresa")]
        public Empresa Empresa { get; set; }
    }
}
