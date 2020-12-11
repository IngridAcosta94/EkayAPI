using Ekay.Domain.Entities;
using Ekay.Domain.QueyFilters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ekay.Domain.Interfaces
{
	public interface IDocumentoRepository : IRepository<Documento>
	{
		IEnumerable<Documento> GetDocumentos(DocumentoQueryFilter filter);
		Task<bool> UpdateDocumento(Documento documento);
		Task<Documento> GetDocumento(int id);

	}
}
