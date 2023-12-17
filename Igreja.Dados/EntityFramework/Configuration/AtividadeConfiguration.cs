using Igreja.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Dados.EntityFramework.Configuration
{
    public class AtividadeConfiguration: IEntityTypeConfiguration<Atividades>
    {
        public void Configure(EntityTypeBuilder<Atividades> builder)
        {
            builder.ToTable("Atividades");
            builder.HasKey(e => e.AtividadeID);

            builder
                  .Property(e => e.AtividadeID)
                  .HasColumnName("AtividadeID")
                  .HasColumnType("int");
            builder
                  .Property(e => e.AtividadeNome)
                  .HasColumnName("AtividadeNome")
                  .HasColumnType("varchar(50)");
            builder
                  .Property(e => e.Descricao)
                  .HasColumnName("Descricao")
                  .HasColumnType("varchar(200)");
            builder
                  .Property(e => e.DataAtividade)
                  .HasColumnName("DataAtividade")
                  .HasColumnType("DateTime");
        }
    }
}
