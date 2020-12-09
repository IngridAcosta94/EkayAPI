using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ekay.Clases
{
	public class RemitenteRequestDto
	{
		[Required(ErrorMessage = "Proporcione un nombre.")]
		public string Nombre { get; set; }
		[Required(ErrorMessage = "Proporcione un apellido.")]
		public string Apellido { get; set; }
		[Required(ErrorMessage = "Proporcione un correo electronico.")]
		public string Correo { get; set; }
		[Required(ErrorMessage = "Proporcione un numero telefonico.")]
		public string Telefono { get; set; }







	}
}
