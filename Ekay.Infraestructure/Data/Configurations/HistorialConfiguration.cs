using Ekay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekay.Infraestructure.Data.Configurations
{
	public class HistorialConfiguration : IEntityTypeConfiguration<Historial>
    {
		

		public void Configure(EntityTypeBuilder<Historial> builder)
		{
            builder.Property(e => e.Descripcion)
                   .HasMaxLength(200)
                   .IsUnicode(false);

            builder.Property(e => e.Fecha).HasColumnType("datetime");

           /* builder.HasOne(d => d.Documento)
                .WithMany(p => p.Historial)
                .HasForeignKey(d => d.DocumentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historial_0");*/

            builder.HasOne(d => d.Estatus)
                .WithMany(p => p.Historial)
                .HasForeignKey(d => d.EstatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historial_1");
            builder.Ignore(e => e.CreateAt);
            builder.Ignore(e => e.CreatedBy);
            builder.Ignore(e => e.UpdateAt);
            builder.Ignore(e => e.UpdatedBy);
        }
	}
}
