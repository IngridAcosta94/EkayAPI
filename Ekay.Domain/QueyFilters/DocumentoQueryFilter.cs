using System;
using System.Collections.Generic;
using System.Text;

namespace Ekay.Domain.QueyFilters
{
	public class DocumentoQueryFilter
	{


       
        public DateTime? FechaCreacion { get; set; }
        public int? Autor { get; set; }
        public int? Remitente { get; set; }
        public int? Firmante { get; set; }


        public string NombreArchivo { get; set; }
        public string Contenido { get; set; }




    }
}
