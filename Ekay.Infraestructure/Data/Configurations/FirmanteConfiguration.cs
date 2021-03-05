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
            builder.Property(e => e.ApellidoF)
                    .HasMaxLength(100)
                    .IsUnicode(false);

            builder.Property(e => e.CorreoF)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.NombreF)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Organizacion)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Puesto)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.TelefonoF)
                .HasMaxLength(10)
                .IsUnicode(false);

           /* builder.HasOne(d => d.Documento)
                .WithMany(p => p.Firmante)
                .HasForeignKey(d => d.DocumentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Firmante_0");*/


          

            builder.Ignore(e => e.CreateAt);
            builder.Ignore(e => e.CreatedBy);
            builder.Ignore(e => e.UpdateAt);
            builder.Ignore(e => e.UpdatedBy);
        }
	}
}
