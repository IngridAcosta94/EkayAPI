
using System;
using System.Collections.Generic;

namespace Ekay.Domain.Entities
{
    public partial class Documento : BaseEntity
    {
        public Documento()
        {
            Firmante = new HashSet<Firmante>();
            Historial = new HashSet<Historial>();
        }

       // public int DocumentoId { get; set; }
        //public string Titulo { get; set; }
        //public string EnlaceUrl { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Contenido { get; set; }
        public int RemitenteId { get; set; }
        public int AutorId { get; set; }
        public int TipoDocId { get; set; }
        public int CarpetaId { get; set; }
		public string NombreArchivo { get; set; }
		public string Extension { get; set; }
		public double Tamanio { get; set; }
		public string Ruta { get; set; }


		public virtual Autor Autor { get; set; }
        public virtual Carpeta Carpeta { get; set; }
        public virtual Remitente Remitente { get; set; }
        public virtual TipoDocumento TipoDoc { get; set; }
        public virtual ICollection<Firmante> Firmante { get; set; }
        public virtual ICollection<Historial> Historial { get; set; }
    }
}
