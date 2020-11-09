using Ekay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekay.Infraestructure.Data.Configurations
{
	public class EstatusConfiguration : IEntityTypeConfiguration<Estatus>
	{
		

		public void Configure(EntityTypeBuilder<Estatus> builder)
		{
			builder.Property(e => e.Id).ValueGeneratedNever();

			builder.Property(e => e.Descripcion)
				.HasMaxLength(50)
				.IsUnicode(false);
			builder.Ignore(e => e.CreateAt);
			builder.Ignore(e => e.CreatedBy);
			builder.Ignore(e => e.UpdateAt);
			builder.Ignore(e => e.UpdatedBy);

		}
	}
}
