
using System;
using System.Collections.Generic;

namespace Ekay.Domain.Entities
{
    public partial class Autor: BaseEntity
    {
        public Autor()
        {
            Documento = new HashSet<Documento>();
        }

        //public int AutorId { get; set; }
        public string NombreA { get; set; }
        public string ApellidoA { get; set; }
        public string CorreoA { get; set; }
        public int EmpresaId { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<Documento> Documento { get; set; }
    }
}
