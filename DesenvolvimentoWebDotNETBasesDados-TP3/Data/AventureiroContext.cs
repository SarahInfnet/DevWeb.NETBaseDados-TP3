using DesenvolvimentoWebDotNETBasesDados_TP3.Models;
using Microsoft.EntityFrameworkCore;

namespace DesenvolvimentoWebDotNETBasesDados_TP3.Data
{
    public class AventureiroContext : DbContext
    {
        public AventureiroContext(DbContextOptions<AventureiroContext> opcoes) : base(opcoes)
        {
        }

        public DbSet<Especialidade> Especialidades { get; set;}

        public DbSet<Investidura> Investiduras { get; set;}

        public DbSet<Aventureiro> Aventureiros { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aventureiro>().ToTable("Aventureiro");
            modelBuilder.Entity<Investidura>().ToTable("Investidura");
            modelBuilder.Entity<Especialidade>().ToTable("Especialidade");
        }
    }
}
