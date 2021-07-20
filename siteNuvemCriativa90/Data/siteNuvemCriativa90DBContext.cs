
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using siteNuvemCriativa90.Models;

namespace siteNuvemCriativa90.Data
{
    public class siteNuvemCriativa90DBContext : IdentityDbContext
    {
        public siteNuvemCriativa90DBContext(DbContextOptions<siteNuvemCriativa90DBContext> options)
         : base(options)
        {
            
        }
        public DbSet<Arquivo> Arquivos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Formulario> Formularios { get; set; }
        public DbSet<GrupoUsuario> GrupoUsuarios { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Permissoes> Permissoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

      
    }
}

