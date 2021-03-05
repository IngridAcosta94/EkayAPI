using Ekay.Domain.Entities;
using Ekay.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Ekay.Domain.QueyFilters;

namespace Ekay.Application.Services
{
	public class FirmanteService : IFirmanteService
	{
		private readonly IUnitOfWork _unitOfWork;
		public FirmanteService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}

		public async Task AddFirmante(Firmante firmante)
		{
			Expression<Func<Firmante, bool>> exprFirmante = item => item.NombreF == firmante.NombreF;
			var firmantes = _unitOfWork.FirmanteRepository.FindByCondition(exprFirmante);


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

			await _unitOfWork.FirmanteRepository.Add(firmante);
		}

		public async Task DeleteFirmante(int id)
		{
			await _unitOfWork.FirmanteRepository.Delete(id);
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task<Firmante> GetFirmante(int id)
		{
			return await _unitOfWork.FirmanteRepository.GetById(id);
		}

		public IEnumerable<Firmante> GetFirmantes(FirmanteQueyFilter filter)
		{
			return _unitOfWork.FirmanteRepository.GetFirmantes(filter);
		}

	


		public void UpdateFirmante(Firmante firmante)
		{
			_unitOfWork.FirmanteRepository.Update(firmante);
			_unitOfWork.SaveChangesAsync();
		}

		


	}
}
