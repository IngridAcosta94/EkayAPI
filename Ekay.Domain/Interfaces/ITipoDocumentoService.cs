using Ekay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ekay.Domain.Interfaces
{
	public interface ITipoDocumentoService
	{
		IEnumerable<TipoDocumento> GetTipoDocumentos();
		Task<TipoDocumento> GetTipoDocumento(int id);
		Task AddTipoDocumento(TipoDocumento tipoDocumento);
		void UpdateTipoDocumento(TipoDocumento tipoDocumento);
		Task DeleteTipoDocumento(int id);



	}
}
