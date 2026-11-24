using Exo.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace Exo.WebApi.Contexts
{
    public class ExoContext : DbContext
    {
        public ExoContext()
        {
        }

        public ExoContext(DbContextOptions<ExoContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Essa string de conexao depende da SUA maquina.
                // Exemplo padrao com Autenticacao do Windows:
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ExoApi;Trusted_Connection=True;TrustServerCertificate=True;");
                // Exemplo com autenticacao SQL (sa):
                // optionsBuilder.UseSqlServer("User ID=sa;Password=admin;Server=localhost;Database=ExoApi;Trusted_Connection=False;TrustServerCertificate=True;");
            }
        }

        public DbSet<Projeto> Projetos { get; set; }
    }
}
