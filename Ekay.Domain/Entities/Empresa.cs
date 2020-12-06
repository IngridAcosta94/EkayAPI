using System;
using System.Collections.Generic;

namespace Ekay.Domain.Entities
{
    public partial class Empresa : BaseEntity
    {
        public Empresa()
        {
            Autor = new HashSet<Autor>();
            Carpeta = new HashSet<Carpeta>();
            Cuenta = new HashSet<Cuenta>();
        }

        //public int EmpresaId { get; set; }
        public string Nombre { get; set; }
        
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
       public string NombreRepresentante { get; set; }

        public virtual ICollection<Autor> Autor { get; set; }
        public virtual ICollection<Carpeta> Carpeta { get; set; }
        public virtual ICollection<Cuenta> Cuenta { get; set; }
    }
}
