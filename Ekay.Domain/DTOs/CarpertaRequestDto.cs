using System;
using System.Collections.Generic;
using System.Text;

namespace Ekay.Domain.DTOs
{
	public class CarpertaRequestDto
	{
		public string Nombre { get; set; }
		public DateTime? FechaCreacion { get; set; }
		public int EmpresaId { get; set; }
	}
}
