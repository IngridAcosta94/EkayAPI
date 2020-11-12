using Ekay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ekay.Domain.Interfaces
{
	public interface IFirmanteService
	{
		IEnumerable<Firmante> GetFirmantes();
		Task<Firmante> GetFirmante(int id);
		Task AddFirmante(Firmante firmante);
		void UpdateFirmante(Firmante firmante);
		Task DeleteFirmante(int id);
	}
}
