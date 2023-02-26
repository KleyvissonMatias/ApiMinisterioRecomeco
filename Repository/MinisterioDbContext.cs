using ApiMinisterioRecomeco.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMinisterioRecomeco.Repository
{
    public class MinisterioDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public MinisterioDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Celula> Celulas { get; set; }

        public DbSet<Vida> Vidas { get; set; }

        public DbSet<Relatorio> Relatorios { get; set; }

        public DbSet<Voluntario> Voluntarios { get; set; }
    }
}
