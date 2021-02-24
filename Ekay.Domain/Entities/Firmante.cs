using System;
using System.Collections.Generic;

namespace Ekay.Domain.Entities
{
    public partial class Firmante : BaseEntity
    {


        public Firmante()
        {
            Documento = new HashSet<Documento>();
            //Historial = new HashSet<Historial>();
        }

        //public int FirmanteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Puesto { get; set; }
        public string Organizacion { get; set; }
        public int DocumentoId { get; set; }

        //public virtual Documento Documento { get; set; }

        public virtual ICollection<Documento> Documento { get; set; }
    }
}
