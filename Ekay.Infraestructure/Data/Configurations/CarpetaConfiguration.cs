using Ekay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekay.Infraestructure.Data.Configurations
{
    public class CarpetaConfiguration : IEntityTypeConfiguration<Carpeta>
    {
        
		public void Configure(EntityTypeBuilder<Carpeta> builder)
		{
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");

            builder.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

            builder.HasOne(d => d.Empresa)
                    .WithMany(p => p.Carpeta)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Carpeta_0");
            builder.Ignore(e => e.CreateAt);
            builder.Ignore(e => e.CreatedBy);
            builder.Ignore(e => e.UpdateAt);
            builder.Ignore(e => e.UpdatedBy);
        }
	}
}
