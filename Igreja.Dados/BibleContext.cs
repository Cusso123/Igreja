using Humanizer.Localisation;
using Igreja.Dados.EntityFramework.Configuration;
using Igreja.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Dados
{
    public class BibleContext : DbContext
    {
        public BibleContext(DbContextOptions<BibleContext> options) : base(options) { }
        public DbSet<Verse> Verses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source = 201.62.57.93, 1434; 
                                        Database = BD034287; 
                                        User ID = RA034287; 
                                        Password = 034287;
                                        TrustServerCertificate = True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MembroCadastroConfiguration());
        }
    }
}
