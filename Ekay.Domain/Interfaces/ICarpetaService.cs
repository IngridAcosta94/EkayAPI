using Ekay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ekay.Domain.Interfaces
{
	public interface ICarpetaService
	{
		IEnumerable<Carpeta> Getcarpetas();
		Task<Carpeta> Getcarpeta(int id);
		Task AddCarpeta(Carpeta carpeta);
		void UpdateCarpeta(Carpeta carpeta);
		Task DeleteCarpeta(int id);
	}
}
