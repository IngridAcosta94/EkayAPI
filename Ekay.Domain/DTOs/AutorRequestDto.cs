using System;
using System.Collections.Generic;
using System.Text;

namespace Ekay.Domain.DTOs
{
	public class AutorRequestDto
	{
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Correo { get; set; }
		public int EmpresaId { get; set; }
	}
}
