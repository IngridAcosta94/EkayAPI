using System;
using System.Collections.Generic;
using System.Text;

namespace Ekay.Domain.DTOs
{
	public class FirmanteResponseDto
	{
        public int Id { get; set; }
        public string NombreF { get; set; }
        public string ApellidoF { get; set; }
        public string CorreoF { get; set; }
        public string TelefonoF { get; set; }
        public string Puesto { get; set; }
        public string Organizacion { get; set; }
     //   public int DocumentoId { get; set; }

        //public string RutaBase { get; set; }

    }
}
