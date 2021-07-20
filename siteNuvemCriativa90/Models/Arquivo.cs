using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace siteNuvemCriativa90.Models
{
    public class Arquivo
    {
        [Key]
        public int IDArquivo { get; set; }
        [StringLength(50, ErrorMessage="Somente 50 caracteres")]
        [Required]
        [Display(Name = "Nome Arquivo")]
        public string NomeArquivo { get; set; }
        [StringLength(100, ErrorMessage = "Somente 100 caracteres")]
        [Required]
        [Display(Name = "Caminho Arquivo")]
        public string CaminhoArquivo { get; set; }
        [StringLength(200, ErrorMessage = "Somente 200 caracteres")]
        [Display(Name = "Observação")]
        public string Observacao { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Cadastro")]
        public DateTime DataCadastro { get; set; }
        [StringLength(1)]
        [Required]
        public string Apagado  { get; set; }

        [Display(Name = "Portfolio")]
        public int IDPortfolio { get; set; }
        [ForeignKey("IDPortfolio")]
        public Portfolio Portfolio { get; set; }
    }
}
