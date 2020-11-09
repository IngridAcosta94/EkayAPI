using Ekay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekay.Infraestructure.Data.Configurations
{
	public class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumento>
	{
		

		public void Configure(EntityTypeBuilder<TipoDocumento> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.NombreDoc)
				.HasMaxLength(100)
				.IsUnicode(false);
			builder.Ignore(e => e.CreateAt);
			builder.Ignore(e => e.CreatedBy);
			builder.Ignore(e => e.UpdateAt);
			builder.Ignore(e => e.UpdatedBy);

		}
	}
}
