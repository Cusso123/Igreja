using Igreja.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Dados.EntityFramework.Configuration
{
    public class PerfilConfiguration : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("Perfil");
            builder.HasKey(x => x.PerfilID);



            builder
                .Property(e => e.PerfilID)
                .HasColumnName("PerfilID")
                .HasColumnType("int");

            builder
                .Property(e => e.NomePerfil)
                .HasColumnName("NomePerfil")
                .HasColumnType("varchar(100)");
        }

    }
}
