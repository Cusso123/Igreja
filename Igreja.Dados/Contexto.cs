using System;
using Igreja.Dados.EntityFramework.Configuration;
using Igreja.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Igreja.Dados
{
    public class Contexto : DbContext
    {
        public DbSet<MembroCadastro> MembroCadastro { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source = 201.62.57.93, 1434; 
                                        Database = BD044983; 
                                        User ID = RA044983; 
                                        Password = 044983;
                                        TrustServerCertificate = True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MembroCadastroConfiguration());
        }

    }
}

