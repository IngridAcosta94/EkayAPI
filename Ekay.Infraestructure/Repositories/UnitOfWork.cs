using Ekay.Domain.Entities;
using Ekay.Domain.Interfaces;
using Ekay.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ekay.Infraestructure.Repositories
{
	public sealed class UnitOfWork : IUnitOfWork
	{
		private readonly EkayContext _context;
		public UnitOfWork(EkayContext context)
		{
			this._context = context;
		}


		private readonly IRepository<Autor> _autorRepository;
		private readonly IRepository<Carpeta> _carpetaRepository;
		private readonly IRepository<Cuenta> _cuentaRepository;
		private readonly IRepository<Documento> _documentoRepository;
		private readonly IRepository<Empresa> _empresaRepository;
		private readonly IRepository<Estatus> _estatusRepository;
		private readonly IRepository<Firmante> _firmanteRepository;
		private readonly IRepository<Historial> _historialRepository;
		private readonly IRepository<Perfil> _perfilRepository;
		private readonly IRepository<Remitente> _remitenteRepository;
		private readonly IRepository<TipoDocumento> _tipoDocumentoRepository;
		public IRepository<Autor> AutorRepository => _autorRepository ?? new SQLRepository<Autor>(_context);


		public IRepository<Carpeta> CarpetaRepository => _carpetaRepository ?? new SQLRepository<Carpeta>(_context);

		public IRepository<Cuenta> CuentaRepository => _cuentaRepository ?? new SQLRepository<Cuenta>(_context);
		public IRepository<Documento> DocumentoRepository => _documentoRepository ?? new SQLRepository<Documento>(_context);

		public IRepository<Empresa> EmpresaRepository => _empresaRepository ?? new SQLRepository<Empresa>(_context);

		public IRepository<Estatus> EstatusRepository => _estatusRepository ?? new SQLRepository<Estatus>(_context);

		public IRepository<Firmante> FirmanteRepository => _firmanteRepository ?? new SQLRepository<Firmante>(_context);

		public IRepository<Historial> HistorialRepository => _historialRepository ?? new SQLRepository<Historial>(_context);

		public IRepository<Perfil> PerfilRepository => _perfilRepository ?? new SQLRepository<Perfil>(_context);

		public IRepository<Remitente> RemitenteRepository => _remitenteRepository ?? new SQLRepository<Remitente>(_context);

		public IRepository<TipoDocumento> TipoDocumentoRepository => _tipoDocumentoRepository ?? new SQLRepository<TipoDocumento>(_context);

		public void Dispose()
		{
			if (_context == null)
				_context.Dispose();
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
