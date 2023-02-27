using ApiMinisterioRecomeco.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMinisterioRecomeco.Configuration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Celula> Celulas { get; set; }

        public DbSet<Vida> Vidas { get; set; }

        public DbSet<Relatorio> Relatorios { get; set; }

        public DbSet<Voluntario> Voluntarios { get; set; }
    }
}
