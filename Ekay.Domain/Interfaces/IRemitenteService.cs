using Ekay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ekay.Domain.Interfaces
{
	public interface IRemitenteService
	{
		IEnumerable<Remitente> GetRemitentes();
		Task<Remitente> GetRemitente(int id);
		Task AddRemitente(Remitente remitente);
		void UpdateRemitente(Remitente remitente);
		Task DeleteRemitente(int id);
	}
}
