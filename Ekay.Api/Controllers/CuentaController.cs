using AutoMapper;
using Ekay.Api.Responses;
using Ekay.Domain.DTOs;
using Ekay.Domain.Entities;
using Ekay.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekay.Api.Controllers
{
    public class CuentaController : ControllerBase
    {
        [Route("api/[controller]")]
        [ApiController]
        public class EmpresaController : ControllerBase
        {


            private readonly ICuentaService _service;
            private readonly IMapper _mapper;
            public EmpresaController(ICuentaService service, IMapper mapper)
            {
                _service = service;
                this._mapper = mapper;

            }




            [HttpGet]
            public async Task<IActionResult> Get()
            {
                var cuentas = _service.GetCuentas();
                var CuentasDto = _mapper.Map<IEnumerable<Cuenta>, IEnumerable<CuentaResponseDto>>(cuentas);
                var response = new ApiResponse<IEnumerable<CuentaResponseDto>>(CuentasDto);
                return Ok(response);
            }
            [HttpGet("{id:int}")]
            public async Task<IActionResult> Get(int id)
            {
                var cuenta = await _service.GetCuenta(id);
                var cuentaDto = _mapper.Map<Cuenta, CuentaResponseDto>(cuenta);
                var response = new ApiResponse<CuentaResponseDto>(cuentaDto);
                return Ok(response);

            }

            [HttpPost]
            public async Task<IActionResult> Post(int id, CuentaRequestDto cuentaDto)

            {
                var cuenta = _mapper.Map<CuentaRequestDto, Cuenta>(cuentaDto);
                await _service.AddCuenta(cuenta);
                var cuentaresponseDto = _mapper.Map<Cuenta, CuentaResponseDto>(cuenta);
                var response = new ApiResponse<CuentaResponseDto>(cuentaresponseDto);
                return Ok(response);






            }

            [HttpDelete("{id:int}")]
            public async Task<ActionResult> Delete(int id)
            {
                await _service.DeleteCuenta(id);
                var response = new ApiResponse<bool>(true);
                return Ok(response);

            }
            [HttpPut]
            public async Task<IActionResult> Put(int id, CuentaRequestDto cuentaDto)
            {

                var cuenta = _mapper.Map<Cuenta>(cuentaDto);
                cuenta.Id = id;
                cuenta.UpdateAt = DateTime.Now;
                cuenta.UpdatedBy = 2;
                _service.UpdateCuenta(cuenta);
                var response = new ApiResponse<bool>(true);
                return Ok(response);
            }



        }
    }

}
