using Ekay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekay.Infraestructure.Data.Configurations
{
    public class AutorConfiguration : IEntityTypeConfiguration<Autor>
    {
       

		public void Configure(EntityTypeBuilder<Autor> builder)
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

            builder.HasOne(d => d.Empresa)
                .WithMany(p => p.Autor)
                .HasForeignKey(d => d.EmpresaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Autor_0");
            builder.Ignore(e => e.CreateAt);
            builder.Ignore(e => e.CreatedBy);
            builder.Ignore(e => e.UpdateAt);
            builder.Ignore(e => e.UpdatedBy);
            //builder.Ignore(e => e.Status);
        }
	}

}
