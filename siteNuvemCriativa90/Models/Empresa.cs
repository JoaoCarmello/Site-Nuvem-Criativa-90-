using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace siteNuvemCriativa90.Models
{
    public class Empresa
    {
        [Key]
        public int IDEmpresa { get; set; }
        [StringLength(50, ErrorMessage = "Somente 50 caracteres")]
        [Required]
        public string Login { get; set; }
        [StringLength(50, ErrorMessage = "Somente 50 caracteres")]
        [Required]
        public string Senha { get; set; }
        [StringLength(20, ErrorMessage = "Somente 20 caracteres")]
        [Required]
        public string CNPJ { get; set; }
        [StringLength(50, ErrorMessage = "Somente 50 caracteres")]
        [Required]
        [Display(Name = "Razão social")]
        public string RazaoSocial { get; set; }
        [StringLength(50, ErrorMessage = "Somente 50 caracteres")]
        [Required]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }
        [StringLength(50, ErrorMessage = "Somente 50 caracteres")]
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [StringLength(15, ErrorMessage = "Somente 15 caracteres")]
        [Required]
        public string Telefone { get; set; }
        [StringLength(200, ErrorMessage = "Somente 200 caracteres")]
        [Required]
        public string Necessidade { get; set; }
        [StringLength(25, ErrorMessage = "Somente 25 caracteres")]
        [Required]
        public string Ramo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Cadastro")]
        public DateTime DataCadastro { get; set; }
        [StringLength(1)]
        [Required]

        public string Apagado { get; set; }
        [Display(Name = "Endereço")]
        public int IDEndereco { get; set; }
        [ForeignKey("IDEndereco")]
        public Endereco Endereco { get; set; }
        [Display(Name = "Grupo Usuário")]
        public int IDGrupoUsuario { get; set; }
        [ForeignKey("IDGrupoUsuario")]
        [Display(Name = "Grupo Usuário")]
        public GrupoUsuario GrupoUsuario { get; set; }

    }
}
