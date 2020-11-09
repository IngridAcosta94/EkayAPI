using System;
using System.Collections.Generic;

namespace Ekay.Domain.Entities
{
    public partial class Remitente : BaseEntity
    {
        public Remitente()
        {
            Documento = new HashSet<Documento>();
        }

        //public int RemitenteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Documento> Documento { get; set; }
    }
}
