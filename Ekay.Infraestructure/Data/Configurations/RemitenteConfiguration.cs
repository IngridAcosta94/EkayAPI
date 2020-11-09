using Ekay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekay.Infraestructure.Data.Configurations
{
	public class RemitenteConfiguration : IEntityTypeConfiguration<Remitente>
    {

		

		public void Configure(EntityTypeBuilder<Remitente> builder)
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

            builder.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false);
            builder.Ignore(e => e.CreateAt);
            builder.Ignore(e => e.CreatedBy);
            builder.Ignore(e => e.UpdateAt);
            builder.Ignore(e => e.UpdatedBy);
        }
	}
}
