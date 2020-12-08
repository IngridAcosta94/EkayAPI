using Ekay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekay.Infraestructure.Data.Configurations
{
	public class FirmanteConfiguration : IEntityTypeConfiguration<Firmante>
    {
		

		public void Configure(EntityTypeBuilder<Firmante> builder)
		{
            builder.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false);

            builder.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Organizacion)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Puesto)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false);

            /*builder.HasOne(d => d.Documento)
                .WithMany(p => p.Firmante)
                .HasForeignKey(d => d.DocumentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Firmante_0");
            builder.Ignore(e => e.CreateAt);
            builder.Ignore(e => e.CreatedBy);
            builder.Ignore(e => e.UpdateAt);
            builder.Ignore(e => e.UpdatedBy);*/
        }
	}
}
