using System;
using System.Collections.Generic;

namespace Ekay.Domain.Entities
{
    public partial class Historial : BaseEntity
    {
        //public int HistorialId { get; set; }
        public DateTime? Fecha { get; set; }
        public string Descripcion { get; set; }
        public int DocumentoId { get; set; }
        public int EstatusId { get; set; }

        public virtual Documento Documento { get; set; }
        public virtual Estatus Estatus { get; set; }
    }
}
