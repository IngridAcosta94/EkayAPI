using System;
using System.Collections.Generic;

namespace Ekay.Domain.Entities
{
    public partial class Cuenta : BaseEntity
    {
        //public int CuentaId { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public int PerfilId { get; set; }
        public int EmpresaId { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}
