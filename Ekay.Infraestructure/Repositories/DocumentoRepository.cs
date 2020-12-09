using Ekay.Domain.Entities;
using Ekay.Domain.Interfaces;
using Ekay.Domain.QueyFilters;
using Ekay.Infraestructure.Data;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ekay.Infraestructure.Repositories
{
	class DocumentoRepository : SQLRepository<Documento>, IDocumentoRepository
	{

		private readonly EkayContext _context;
		public DocumentoRepository(EkayContext context) : base(context)
		{
			this._context = context;
		}

		public IEnumerable<Documento> GetDocumentos(DocumentoQueryFilter filter)
		{
			Expression<Func<Documento, bool>> exprFinal = documento => documento.Id > 0;

			if (!string.IsNullOrEmpty(filter.NombreArchivo) && !string.IsNullOrWhiteSpace(filter.NombreArchivo))
			{
				Expression<Func<Documento, bool>> expr = documento => documento.NombreArchivo.Contains(filter.NombreArchivo);
				exprFinal = exprFinal.And(expr);
			}
			if (filter.FechaCreacion.HasValue && filter.FechaCreacion.HasValue)
			{
				Expression<Func<Documento, bool>> expr = documento => documento.FechaCreacion.Value.Date >= filter.FechaCreacion.Value.Date
				 && documento.FechaCreacion.Value.Date <= filter.FechaCreacion.Value.Date;
				exprFinal = exprFinal.And(expr);
			}


			if (filter.Autor.HasValue)
			{
				Expression<Func<Documento, bool>> expr = documento => documento.AutorId == filter.Autor.Value;
				exprFinal = exprFinal.And(expr);
			}
			if (filter.Remitente.HasValue)
			{
				Expression<Func<Documento, bool>> expr = documento => documento.AutorId == filter.Remitente.Value;
				exprFinal = exprFinal.And(expr);
			}

			return FindByCondition(exprFinal);
		}
	}
}
