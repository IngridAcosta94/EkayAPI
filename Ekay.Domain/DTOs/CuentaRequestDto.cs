using Ekay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekay.Domain.DTOs
{
	public class CuentaRequestDto
	{
		public string Usuario { get; set; }
		public string Contrasenia { get; set; }
		//public int PerfilId { get; set; }
		//public int EmpresaId { get; set; }

		//public Empresa Empresa { get; set; }

		//public string Empresa { get; set; }
		public string Nombre { get; set; }
		public string Direccion { get; set; }
		public string Correo { get; set; }
		public string Telefono { get; set; }
		public string NombreRepresentante { get; set; }

	}
}
