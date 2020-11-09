using Ekay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekay.Infraestructure.Data.Configurations
{
	public class PerfilConfiguration : IEntityTypeConfiguration<Perfil>
	{

		

		public void Configure(EntityTypeBuilder<Perfil> builder)
		{
			builder.Property(e => e.Nombre)
					.HasMaxLength(100)
					.IsUnicode(false);

			builder.Ignore(e => e.CreateAt);
			builder.Ignore(e => e.CreatedBy);
			builder.Ignore(e => e.UpdateAt);
			builder.Ignore(e => e.UpdatedBy);
		}
	}
}
