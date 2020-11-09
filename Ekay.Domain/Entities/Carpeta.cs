
using System;
using System.Collections.Generic;

namespace Ekay.Domain.Entities
{
    public partial class Carpeta : BaseEntity
    {
        public Carpeta()
        {
            Documento = new HashSet<Documento>();
        }

        //public int CarpetaId { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int EmpresaId { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<Documento> Documento { get; set; }
    }
}
