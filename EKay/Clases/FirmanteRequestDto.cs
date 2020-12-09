using System;
using System.Collections.Generic;
using System.Text;

namespace Ekay.Clases
{
	public class FirmanteRequestDto
	{
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Puesto { get; set; }
        public string Organizacion { get; set; }
        public int DocumentoId { get; set; }

    }
}
