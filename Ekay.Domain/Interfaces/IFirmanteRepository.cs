using Ekay.Domain.Entities;
using Ekay.Domain.QueyFilters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ekay.Domain.Interfaces
{
	public interface IFirmanteRepository : IRepository<Firmante>
	{


		IEnumerable<Firmante> GetFirmantes(FirmanteQueyFilter filter);
		Task<bool> UpdateFirmante(Firmante firmante);
		Task<Firmante> GetFirmante(int id);

		//Task<Firmante> TraerDatos(int id);







	}
}
