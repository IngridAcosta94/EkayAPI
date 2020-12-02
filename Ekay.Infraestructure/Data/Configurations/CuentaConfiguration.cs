
using Ekay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekay.Infraestructure.Data.Configurations
{
	public class CuentaConfiguration : IEntityTypeConfiguration<Cuenta>
	{

		
        public void Configure(EntityTypeBuilder<Cuenta> builder)
		{
            
            
              
            builder.Property(e => e.Contrasenia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.HasOne(d => d.Empresa)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuenta_0");
            builder.Ignore(e => e.CreateAt);
            builder.Ignore(e => e.CreatedBy);
            builder.Ignore(e => e.UpdateAt);
            builder.Ignore(e => e.UpdatedBy);

        }
	}
}
