using System;
using System.Collections.Generic;

namespace Ekay.Domain.Entities
{
    public partial class TipoDocumento : BaseEntity
    {
        public TipoDocumento()
        {
            Documento = new HashSet<Documento>();
        }

        //public int TipoDocId { get; set; }
        public string NombreDoc { get; set; }

        public virtual ICollection<Documento> Documento { get; set; }
    }
}
