using System;
using System.Collections.Generic;
using System.Text;

namespace Ekay.Domain.DTOs
{
	public class RemitenteResponseDto
	{
		public int id { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Correo { get; set; }
		public string Telefono { get; set; }
	}
}
