using Ekay.Domain.Entities;
using Ekay.Domain.Exceptions;
using Ekay.Domain.Interfaces;
using Ekay.Domain.QueyFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ekay.Application.Services
{
	public class DocumentoService : IDocumentoService
	{
		private readonly IUnitOfWork _unitOfWork;
	
		public DocumentoService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}

		public async Task AddDocumento(Documento documento)
		{
			Expression<Func<Documento, bool>> exprDocumento = item => item.NombreArchivo == documento.NombreArchivo;
			var documentos = _unitOfWork.DocumentoRepository.FindByCondition(exprDocumento);


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

			await _unitOfWork.DocumentoRepository.Add(documento);
		}

		public async Task DeleteDocumento(int id)
		{
			await _unitOfWork.DocumentoRepository.Delete(id);
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task<Documento> GetDocumento(int id)
		{
			return await _unitOfWork.DocumentoRepository.GetById(id);
		}

		


		public IEnumerable<Documento> GetDocumentos(DocumentoQueryFilter filter)
		{
			return _unitOfWork.DocumentoRepository.GetDocumentos( filter);
		}

		





		public async Task UpdateDocumento(Documento documento)
		
		{
			try
			{
				var docto = await _unitOfWork.DocumentoRepository.GetById(documento.Id);
				docto.Certificado = documento.Certificado;
				_unitOfWork.DocumentoRepository.Update(docto);
				await _unitOfWork.SaveChangesAsync();
			}
			catch(Exception ex)
			{
				string hola = (ex.Message);
			}
		}



















		/*public async Task AddDocumento(Documento documento)
		{
			await _unitOfWork.AddDocumento(documento);
			
		}
		public async Task DeleteDocumento(int id)
		{
			await _unitOfWork.DeleteDocumento(id);
		}
		public async Task<Documento> GetDocumento(int id)
		{
			return await _unitOfWork.GetDocumento(id);
		}

		public async Task<IEnumerable<Documento>> GetDocumentos()
		{
			 await _unitOfWork.GetDocumentos();
		}
		public async Task<bool> UpdateDocumento(Documento documento)
		{
			return await _unitOfWork.UpdateDocumento(documento);
		}*/



	}
}
