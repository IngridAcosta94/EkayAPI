using Ekay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ekay.Domain.Interfaces
{
	public interface ICuentaService
	{
		IEnumerable<Cuenta> GetCuentas();
		Task<Cuenta> GetCuenta(int id);
		Task AddCuenta(Cuenta cuenta);
		void UpdateCuenta(Cuenta cuenta);
		Task DeleteCuenta(int id);
	}
}
