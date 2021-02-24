using Ekay.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ekay.Domain.Interfaces
{
	public interface IUnitOfWork: IDisposable
	{



		public IRepository<Autor> AutorRepository { get; }
		public IRepository<Carpeta> CarpetaRepository { get; }
		public IRepository<Cuenta> CuentaRepository { get; }
		
		public IRepository<Documento> DocumentoRepository { get; }
		public IRepository<Empresa> EmpresaRepository { get; }
		public IRepository<Estatus> EstatusRepository { get; }
		public IFirmanteRepository FirmanteRepository { get; }
		public IRepository<Historial> HistorialRepository { get; }
		public IRepository<Perfil> PerfilRepository { get; }
		public IRepository<Remitente> RemitenteRepository { get; }
		public IRepository<TipoDocumento> TipoDocumentoRepository { get; }
		void SaveChanges();
		Task SaveChangesAsync();





	}
}
