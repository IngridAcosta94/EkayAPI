using Ekay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ekay.Domain.Interfaces
{
	public interface IDocumentoService
	{

		IEnumerable<Documento> GetDocumentos();
		Task<Documento> GetDocumento(int id);
		Task AddDocumento(Documento documento);
		void UpdateDocumento(Documento documento);
		Task DeleteDocumento(int id);



	}
}
