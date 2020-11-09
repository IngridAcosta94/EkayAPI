using Ekay.Domain.Entities;
using Ekay.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ekay.Application.Services
{
	public class EmpresaService : IEmpresaService
	{

		private readonly IUnitOfWork _unitOfWork;
		public EmpresaService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}

		public async Task AddEmpresa(Empresa empresa)
		{

			Expression<Func<Empresa, bool>> exprEmpresa = item => item.Nombre == empresa.Nombre;
			var empresas = _unitOfWork.EmpresaRepository.FindByCondition(exprEmpresa);


			

			await _unitOfWork.EmpresaRepository.Add(empresa);
		}

		public async Task DeleteEmpresa(int id)
		{
			await _unitOfWork.EmpresaRepository.Delete(id);
			await _unitOfWork.SaveChangesAsync();
		}

		public  IEnumerable<Empresa> GetEmpresas()
		{
			return _unitOfWork.EmpresaRepository.GetAll();
		}

		public async Task <Empresa> GetEmpresa(int id)
		{
			return await _unitOfWork.EmpresaRepository.GetById(id);
		}

		public void UpdateEmpresa(Empresa empresa)
		{
			_unitOfWork.EmpresaRepository.Update(empresa);
			_unitOfWork.SaveChangesAsync();
		}
	}
}
