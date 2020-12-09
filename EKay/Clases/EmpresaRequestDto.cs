using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ekay.Clases
{
	public class EmpresaRequestDto
	{

		[Required(ErrorMessage = "Debe proporcionar el nombre de su empresa.")]
		public string Nombre { get; set; }
		[Required(ErrorMessage = "Debe proporcionar la direccion de su empresa.")]
		public string Direccion { get; set; }
		[Required(ErrorMessage = "Debe proporcionar un correo electrónico valido.")]
		public string Correo { get; set; }
		[Required(ErrorMessage = "Debe proporcionar un numero de telefono valido.")]
		public string Telefono { get; set; }
		[Required(ErrorMessage = "Debe proporcionar el nombre de un representante de su empresa.")]
		public string NombreRepresentante { get; set; }



	}
}
