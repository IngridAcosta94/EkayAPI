using Ekay.Domain.Entities;
using Ekay.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ekay.Application.Services
{
	public class RemitenteService : IRemitenteService
	{
		private readonly IUnitOfWork _unitOfWork;
		public RemitenteService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}

		public async Task AddRemitente(Remitente remitente)
		{
			Expression<Func<Remitente, bool>> exprRemitente = item => item.Nombre == remitente.Nombre;
			var remitentes = _unitOfWork.RemitenteRepository.FindByCondition(exprRemitente);


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

			await _unitOfWork.RemitenteRepository.Add(remitente);
		}

		public async Task DeleteRemitente(int id)
		{
			await _unitOfWork.RemitenteRepository.Delete(id);
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task<Remitente> GetRemitente(int id)
		{
			return await _unitOfWork.RemitenteRepository.GetById(id);
		}

		public IEnumerable<Remitente> GetRemitentes()
		{
			return _unitOfWork.RemitenteRepository.GetAll();
		}

		public void UpdateRemitente(Remitente remitente)
		{
			_unitOfWork.RemitenteRepository.Update(remitente);
			_unitOfWork.SaveChangesAsync();
		}
	}
}
