using System;
using System.Collections.Generic;
using System.Text;

namespace Ekay.Domain.QueyFilters
{
	public class FirmanteQueyFilter
	{
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Puesto { get; set; }
        public string Organizacion { get; set; }
        public int? Documento { get; set; }
    }
}
