using Ekay.Domain.Entities;
using Ekay.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ekay.Application.Services
{
	class CarpetaService : ICarpetaService
	{
		private readonly IUnitOfWork _unitOfWork;
		public CarpetaService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}

		public async Task AddCarpeta(Carpeta carpeta)
		{
			Expression<Func<Carpeta, bool>> exprCarpeta = item => item.Nombre == carpeta.Nombre;
			var carpetas = _unitOfWork.CarpetaRepository.FindByCondition(exprCarpeta);


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

			await _unitOfWork.CarpetaRepository.Add(carpeta);

		}

		public async Task DeleteCarpeta(int id)
		{
			await _unitOfWork.CarpetaRepository.Delete(id);
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task<Carpeta> Getcarpeta(int id)
		{
			return await _unitOfWork.CarpetaRepository.GetById(id);
		}

		public IEnumerable<Carpeta> Getcarpetas()
		{
			return _unitOfWork.CarpetaRepository.GetAll();
		}

		public void UpdateCarpeta(Carpeta carpeta)
		{
			_unitOfWork.CarpetaRepository.Update(carpeta);
			_unitOfWork.SaveChangesAsync();
		}
	}
}
