using System;
using System.Collections.Generic;
using System.Text;

namespace Ekay.Clases
{
	public class CarpetaResponseDto
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public DateTime? FechaCreacion { get; set; }
		public int EmpresaId { get; set; }
	}
}
