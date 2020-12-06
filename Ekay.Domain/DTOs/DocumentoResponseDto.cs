using System;
using System.Collections.Generic;
using System.Text;

namespace Ekay.Domain.DTOs
{
	public class DocumentoResponseDto
	{


        public int Id { get; set; }

        public string NombreA { get; set; }
        public string ApellidoA { get; set; }
        public string CorreoA { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }

        //public string Titulo { get; set; }
        //public string EnlaceUrl { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Contenido { get; set; }
        public int RemitenteId { get; set; }
        public int AutorId { get; set; }
                public int TipoDocId { get; set; }
                public int CarpetaId { get; set; }
                public string NombreArchivo { get; set; }
                public string Extension { get; set; }
                public double Tamanio { get; set; }
                public string Ruta { get; set; }
                public string RutaBase { get; set; }
                public string Certificado { get; set; }




    }

  
    
}
