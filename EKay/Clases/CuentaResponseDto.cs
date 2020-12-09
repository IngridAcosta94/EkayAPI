using Ekay.Clases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekay.Clases
{
	public class CuentaResponseDto
	{
		public int Id { get; set; }
		public string Usuario { get; set; }
		public string Contrasenia { get; set; }
		public int PerfilId { get; set; }
		public int EmpresaId { get; set; }

		//public virtual Empresa Empresa { get; set; }
	}
}
