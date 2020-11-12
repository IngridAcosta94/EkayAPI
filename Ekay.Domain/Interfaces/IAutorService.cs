using Ekay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ekay.Domain.Interfaces
{
	public interface IAutorService
	{
		IEnumerable<Autor> GetAutores();
		Task<Autor> GetAutor(int id);
		Task AddAutor(Autor autor);
		void UpdateAutor(Autor autor);
		Task DeleteAutor(int id);
	}
}
