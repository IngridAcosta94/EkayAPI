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
    public class TipoDocumentoController : ControllerBase
    {
        private readonly ITipoDocumentoService _service;
        private readonly IMapper _mapper;
        public TipoDocumentoController(ITipoDocumentoService service, IMapper mapper)
        {
            _service = service;
            this._mapper = mapper;

        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tipoDocumentos = _service.GetTipoDocumentos();
            var TipoDocumentosDto = _mapper.Map<IEnumerable<TipoDocumento>, IEnumerable<TipoDocumentoResponseDto>>(tipoDocumentos);
            var response = new ApiResponse<IEnumerable<TipoDocumentoResponseDto>>(TipoDocumentosDto);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var tipoDocumentos = await _service.GetTipoDocumento(id);
            var tipoDocumentoDto = _mapper.Map<TipoDocumento, TipoDocumentoResponseDto>(tipoDocumentos);
            var response = new ApiResponse<TipoDocumentoResponseDto>(tipoDocumentoDto);
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> Post(int id, TipoDocumentoRequestDto tipoDocumentoDto)

        {
            var tipoDocumento = _mapper.Map<TipoDocumentoRequestDto, TipoDocumento>(tipoDocumentoDto);
            await _service.AddTipoDocumento(tipoDocumento);
            var tipoDocumentoresponseDto = _mapper.Map < TipoDocumento, TipoDocumentoResponseDto>(tipoDocumento);
            var response = new ApiResponse<TipoDocumentoResponseDto>(tipoDocumentoresponseDto);
            return Ok(response);






        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteTipoDocumento(id);
            var response = new ApiResponse<bool>(true);
            return Ok(response);

        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, TipoDocumentoRequestDto tipoDocumentoDto)
        {

            var tipoDocumento = _mapper.Map<TipoDocumento>(tipoDocumentoDto);
            tipoDocumento.Id = id;
            tipoDocumento.UpdateAt = DateTime.Now;
            tipoDocumento.UpdatedBy = 2;
            _service.UpdateTipoDocumento(tipoDocumento);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }

    }
}
