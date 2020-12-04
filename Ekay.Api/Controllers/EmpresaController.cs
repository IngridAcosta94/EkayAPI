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
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
	{


        private readonly IEmpresaService _service;
        private readonly IMapper _mapper;
        public EmpresaController(IEmpresaService service, IMapper mapper)
        {
            _service = service;
            this._mapper = mapper;

        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var empresas = _service.GetEmpresas();
            var EmpresasDto = _mapper.Map<IEnumerable<Empresa>, IEnumerable<EmpresaResponseDto>>(empresas);
            var response = new ApiResponse<IEnumerable<EmpresaResponseDto>>(EmpresasDto);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var empresa = await _service.GetEmpresa(id);
            var empresaDto = _mapper.Map<Empresa, EmpresaResponseDto>(empresa);
            var response = new ApiResponse<EmpresaResponseDto>(empresaDto);
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> Post( [FromForm] EmpresaRequestDto empresaDto  )

        {
            var empresa = _mapper.Map<EmpresaRequestDto, Empresa>(empresaDto);
            await _service.AddEmpresa(empresa);
            var empresaresponseDto = _mapper.Map<Empresa, EmpresaResponseDto>(empresa);
            var response = new ApiResponse<EmpresaResponseDto>(empresaresponseDto);
            return Ok(response);






        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteEmpresa(id);
            var response = new ApiResponse<bool>(true);
            return Ok(response);

        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, EmpresaRequestDto empresaDto)
        {

            var empresa = _mapper.Map<Empresa>(empresaDto);
            empresa.Id = id;
            empresa.UpdateAt = DateTime.Now;
            empresa.UpdatedBy = 2;
            _service.UpdateEmpresa(empresa);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }


    }
}
