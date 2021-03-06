using Ekay.Domain.Entities;
using Ekay.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ekay.Application.Services
{
	public class TipoDocumentoService : ITipoDocumentoService
	{
		private readonly IUnitOfWork _unitOfWork;
		public TipoDocumentoService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}

		public async Task AddTipoDocumento(TipoDocumento tipoDocumento)
		{
			Expression<Func<TipoDocumento, bool>> exprTipoDocumento = item => item.NombreDoc == tipoDocumento.NombreDoc;
			var remitentes = _unitOfWork.TipoDocumentoRepository.FindByCondition(exprTipoDocumento);

			await _unitOfWork.TipoDocumentoRepository.Add(tipoDocumento);
		}

		public async Task DeleteTipoDocumento(int id)
		{
			await _unitOfWork.TipoDocumentoRepository.Delete(id);
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task<TipoDocumento> GetTipoDocumento(int id)
		{
			return await _unitOfWork.TipoDocumentoRepository.GetById(id);
		}

		public IEnumerable<TipoDocumento> GetTipoDocumentos()
		{
			return _unitOfWork.TipoDocumentoRepository.GetAll();
		}

		public void UpdateTipoDocumento(TipoDocumento tipoDocumento)
		{
			_unitOfWork.TipoDocumentoRepository.Update(tipoDocumento);
			_unitOfWork.SaveChangesAsync();
		}
	}
}
