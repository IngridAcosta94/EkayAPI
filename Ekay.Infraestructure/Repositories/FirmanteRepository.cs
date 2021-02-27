using Ekay.Domain.Entities;
using Ekay.Domain.Interfaces;
using Ekay.Domain.QueyFilters;
using Ekay.Infraestructure.Data;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ekay.Infraestructure.Repositories
{
	public class FirmanteRepository 
	{
		/*private readonly EkayContext _context;
		public FirmanteRepository(EkayContext context) : base(context)
		{
			this._context = context;

		}


		public async Task<Firmante> GetFirmante(int id)
		{
			return await _context.Firmante.SingleOrDefaultAsync(Firmante => Firmante.Id == id)
			?? new Firmante();
		}

		public IEnumerable<Firmante> GetFirmantes(FirmanteQueyFilter filter)
		{
			Expression<Func<Firmante, bool>> exprFinal = firmante => firmante.Id > 0;

			if (!string.IsNullOrEmpty(filter.Nombre) && !string.IsNullOrWhiteSpace(filter.Nombre))
			{
				Expression<Func<Firmante, bool>> expr = firmante => firmante.Nombre.Contains(filter.Nombre);
				exprFinal = exprFinal.And(expr);
			}
		

			return _context.Firmante.Include(a => a.Documento).Where(exprFinal).AsNoTracking().AsEnumerable();
		}

		public async Task<bool> UpdateFirmante(Firmante firmante)
		{
			var current = await GetFirmante(firmante.Id);
			//current.Contenido = documento.Contenido;
			var rowsUpdate = await _context.SaveChangesAsync();
			return rowsUpdate > 0;
		}*/
		

		

	
	}
}
