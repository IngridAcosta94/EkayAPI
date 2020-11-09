using System;
using System.Collections.Generic;

namespace Ekay.Domain.Entities
{
    public partial class Estatus : BaseEntity
    {
        public Estatus()
        {
            Historial = new HashSet<Historial>();
        }

        //public int EstatusId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Historial> Historial { get; set; }
    }
}
