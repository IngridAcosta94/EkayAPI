using Ekay.Domain.Entities;
using Ekay.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ekay.Application.Services
{
	public class CuentaService : ICuentaService
	{
		private readonly IUnitOfWork _unitOfWork;
		public CuentaService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}

		public async Task AddCuenta(Cuenta cuenta)
		{
			Expression<Func<Cuenta, bool>> exprCuenta = item => item.Empresa == cuenta.Empresa;
			var cuentas = _unitOfWork.CuentaRepository.FindByCondition(exprCuenta);




			await _unitOfWork.CuentaRepository.Add(cuenta);
		}

		public async Task DeleteCuenta(int id)
		{
			await _unitOfWork.CuentaRepository.Delete(id);
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task<Cuenta> GetCuenta(int id)
		{
			return await _unitOfWork.CuentaRepository.GetById(id);
		}

		public IEnumerable<Cuenta> GetCuentas()
		{
			return _unitOfWork.CuentaRepository.GetAll();
		}

		public void UpdateCuenta(Cuenta cuenta)
		{
			_unitOfWork.CuentaRepository.Update(cuenta);
			_unitOfWork.SaveChangesAsync();
		}
	}
}
