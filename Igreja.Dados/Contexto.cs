using System;
using Igreja.Dados.EntityFramework.Configuration;
using Igreja.Dominio.Entidades;
using Igreja.Dominion.Entities;
using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext
    {
        public DbSet<Endereco> Endereco { get; set; }

        public Contexto(DbContextOptionsBuilder options) : base(options.Options)
        {
            options.UseSqlServer(@"Data source = 201.62.57.93:1434; 
                                    Database = DB044323; 
                                    User ID = RA044323; 
                                    Password = 044323");

        }

        protected override void OnModeCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
    }

    }

