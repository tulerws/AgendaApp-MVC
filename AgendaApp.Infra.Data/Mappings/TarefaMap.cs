using AgendaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Infra.Data.Mappings
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("TAREFA");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("ID");

            builder.Property(t => t.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.DataHora)
                .HasColumnName("DATAHORA")
                .IsRequired();

            builder.Property(t => t.Prioridade)
                .HasColumnName("PRIORIDADE")
                .IsRequired();

            builder.Property(t => t.UsuarioId)
                .HasColumnName("USUARIO_ID")
                .IsRequired();

            #region Relacionamentos

            builder.HasOne(t => t.Usuario) //Tarefa TEM 1 Usuário
                .WithMany(u => u.Tarefas) //Usuário TEM Muitas Tarefas
                .HasForeignKey(t => t.UsuarioId); //Chave estrangeira

            #endregion
        }
    }
}



