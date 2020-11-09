using System;
using Ekay.Domain.Entities;
using Ekay.Infraestructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace Ekay.Infraestructure.Data
{
    public partial class EkayContext : DbContext
    {
        public EkayContext()
        {
        }

        public EkayContext(DbContextOptions<EkayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<Carpeta> Carpeta { get; set; }
        public virtual DbSet<Cuenta> Cuenta { get; set; }
        public virtual DbSet<Documento> Documento { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Estatus> Estatus { get; set; }
        public virtual DbSet<Firmante> Firmante { get; set; }
        public virtual DbSet<Historial> Historial { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<Remitente> Remitente { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Autor>(new AutorConfiguration());
            modelBuilder.ApplyConfiguration<Carpeta>(new CarpetaConfiguration());
            modelBuilder.ApplyConfiguration<Cuenta>(new CuentaConfiguration());
            modelBuilder.ApplyConfiguration<Documento>(new DocumentoConfiguration());
            modelBuilder.ApplyConfiguration<Empresa>(new EmpresaConfiguration());
            modelBuilder.ApplyConfiguration<Estatus>(new EstatusConfiguration());
            modelBuilder.ApplyConfiguration<Firmante>(new FirmanteConfiguration());
            modelBuilder.ApplyConfiguration<Historial>(new HistorialConfiguration());
            modelBuilder.ApplyConfiguration<Perfil>(new PerfilConfiguration());
            modelBuilder.ApplyConfiguration < Remitente>(new RemitenteConfiguration());
            modelBuilder.ApplyConfiguration<TipoDocumento>(new TipoDocumentoConfiguration());



        }
    }
}
