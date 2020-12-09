using Ekay.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Ekay.Clases
{
	public class CuentaRequestDto
	{
		[Required(ErrorMessage = "Compruebe que ha escrito correctamente el correo.")]
		public string Usuario { get; set; }
		[Required(ErrorMessage = "Debe proporcionar una contraseña valida.")]
		public string Contrasenia { get; set; }
		public int PerfilId { get; set; }
		public int EmpresaId { get; set; }

		//public virtual Empresa Empresa { get; set; }
	}
}
