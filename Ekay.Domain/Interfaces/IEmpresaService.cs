using Ekay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ekay.Domain.Interfaces
{
	public interface IEmpresaService
	{
		IEnumerable<Empresa> GetEmpresas();
		Task<Empresa> GetEmpresa(int id);
		Task AddEmpresa(Empresa empresa);
		void UpdateEmpresa(Empresa empresa);
		Task DeleteEmpresa (int id);

	}
}
