using Ekay.Domain.Entities;
using Ekay.Domain.Interfaces;
using Ekay.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Ekay.Infraestructure.Repositories
{
	public class SQLRepository<T> : IRepository<T> where T : BaseEntity
	{

		private readonly EkayContext _context;
		private readonly DbSet<T> _entities;
		public SQLRepository(EkayContext context)
		{
			this._context = context;
			this._entities = context.Set<T>();
		}


		public async Task Add(T entity)
		{
			if (entity == null) throw new ArgumentNullException("Entity");
			_entities.Add(entity);
			await _context.SaveChangesAsync();
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		//Buscar por medio de las condiciones que se establecieron en las reglas de negocio
		public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
		{
			return _entities.Where(expression).AsNoTracking().AsEnumerable();
		}

		public IEnumerable<T> GetAll()
		{
			
			return _entities.AsNoTracking().AsEnumerable();
		}

		public async Task<T> GetById(int id)
		{
			return await _entities.AsNoTracking().SingleOrDefaultAsync(entity => entity.Id == id);
		}

		public void Update(T entity)
		{
			//if (entity == null) throw new ArgumentNullException("Entity");
			//if (entity.Id <= 0) throw new ArgumentNullException("Entity");
			
			 _entities.Update(entity);
		}
	}
}
