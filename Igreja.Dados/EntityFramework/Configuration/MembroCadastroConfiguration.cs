using Igreja.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Dados.EntityFramework.Configuration
{
    public class MembroCadastroConfiguration : IEntityTypeConfiguration<MembroCadastro>
    {
        public void Configure(EntityTypeBuilder<MembroCadastro> builder)
        {
            builder.ToTable("Membro");
            builder.HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .HasColumnName("ID")
                .HasColumnType("int");

            builder
                .Property(m => m.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(200)");

            builder
                .Property(m => m.Login)
                .HasColumnName("Login")
                .HasColumnType("varchar(50");

            builder
                .Property(m => m.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(200)");


            builder
                .Property(m => m.Senha)
                .HasColumnName("Senha")
                .HasColumnType("varchar(200)");
        }

    }
}