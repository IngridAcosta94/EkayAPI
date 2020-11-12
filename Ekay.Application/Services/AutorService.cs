using Ekay.Domain.Entities;
using Ekay.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ekay.Application.Services
{
	public class AutorService : IAutorService
	{
		private readonly IUnitOfWork _unitOfWork;
		public AutorService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}

		public async Task AddAutor(Autor autor)
		{
			Expression<Func<Autor, bool>> exprAutor = item => item.Nombre == autor.Nombre;
			var autores = _unitOfWork.AutorRepository.FindByCondition(exprAutor);


			//if (animals.Any(item => item.NombreArchivo == documento.NombreArchivo))
			//throw new BusinessException("This animal name already exist.");


			/*var older = DateTime.Now - (documento?.FechaCreacion ?? DateTime.Now);

			if (older.TotalDays > 45)
				throw new BusinessException("The animal's capture date is older than 45 days");
			Expression<Func<Documento, bool>> expressionTag =  => tag.Tag == animal.RfidTag.Tag;
			if (animal.RfidTag != null)
			{
				Expression<Func<RfidTag, bool>> exprTag = item => item.Tag == animal.RfidTag.Tag;
				var tags = _unitOfWork.RfifTagRepository.FindByCondition(exprTag);
			}*/

			await _unitOfWork.AutorRepository.Add(autor);
		}

		public async Task DeleteAutor(int id)
		{
			await _unitOfWork.AutorRepository.Delete(id);
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task<Autor> GetAutor(int id)
		{
			return await _unitOfWork.AutorRepository.GetById(id);
		}

		public IEnumerable<Autor> GetAutores()
		{
			return _unitOfWork.AutorRepository.GetAll();
		}

		public void UpdateAutor(Autor autor)
		{
			_unitOfWork.AutorRepository.Update(autor);
			_unitOfWork.SaveChangesAsync();
		}
	}
}
