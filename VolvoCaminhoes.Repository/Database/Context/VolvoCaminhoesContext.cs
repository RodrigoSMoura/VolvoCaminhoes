using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;
using VolvoCaminhoes.Domain.Entities;

namespace VolvoCaminhoes.Repository.Database.Context
{
    [ExcludeFromCodeCoverage]
    public class VolvoCaminhoesContext : DbContext
    {
        public VolvoCaminhoesContext() { }
        public VolvoCaminhoesContext(DbContextOptions<VolvoCaminhoesContext> options) :base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(DatabaseConnection.Configuration
                                                    .GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Modelo>().HasData(
                new Modelo()
                {
                    Id = 1,
                    Nome = "FH"
                },
                new Modelo()
                {
                    Id = 2,
                    Nome = "FM"
                }
            );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Caminhao> Caminhao { get; set; }
        public DbSet<Modelo> Modelo { get; set; }
    }
}
