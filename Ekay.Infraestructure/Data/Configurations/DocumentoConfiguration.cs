using Ekay.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekay.Infraestructure.Data.Configurations
{
	public class DocumentoConfiguration : IEntityTypeConfiguration<Documento>
    {

		

		public void Configure(EntityTypeBuilder<Documento> builder)
		{
            builder.Property(e => e.Contenido)
                   .HasMaxLength(300)
                   .IsUnicode(false);

           /* builder.Property(e => e.EnlaceUrl)
                .HasColumnName("EnlaceURL")
                .HasMaxLength(500)
                .IsUnicode(false);*/

            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");

            /*builder.Property(e => e.Titulo)
                .HasMaxLength(200)
                .IsUnicode(false);*/

            builder.HasOne(d => d.Autor)
                .WithMany(p => p.Documento)
                .HasForeignKey(d => d.AutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documento_1");

            builder.HasOne(d => d.Carpeta)
                .WithMany(p => p.Documento)
                .HasForeignKey(d => d.CarpetaId)
                .HasConstraintName("FK_Documento_4");

            builder.HasOne(d => d.Remitente)
                .WithMany(p => p.Documento)
                .HasForeignKey(d => d.RemitenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documento_0");

            builder.HasOne(d => d.TipoDoc)
                .WithMany(p => p.Documento)
                .HasForeignKey(d => d.TipoDocId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documento_2");

             builder.Property(e => e.NombreArchivo)
               .HasColumnName("NombreArchivo")
               .HasMaxLength(500)
               .IsUnicode(false);

             builder.Property(e => e.Extension)
               .HasColumnName("Extension")
               .HasMaxLength(500)
               .IsUnicode(false);

             builder.Property(e => e.Tamanio)
               .HasColumnName("Tamanio")
               .HasMaxLength(500)
               .IsUnicode(false);
             
            builder.Property(e => e.Extension)
               .HasColumnName("Extension")
               .HasMaxLength(500)
               .IsUnicode(false);

            builder.Ignore(e => e.CreateAt);
            builder.Ignore(e => e.CreatedBy);
            builder.Ignore(e => e.UpdateAt);
            builder.Ignore(e => e.UpdatedBy);
        }
	}
}
