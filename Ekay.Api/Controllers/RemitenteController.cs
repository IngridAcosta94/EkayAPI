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
    public class RemitenteController : ControllerBase
    {
        private readonly IRemitenteService _service;
        private readonly IMapper _mapper;
        public RemitenteController(IRemitenteService service, IMapper mapper)
        {
            _service = service;
            this._mapper = mapper;

        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var remitentes = _service.GetRemitentes();
            var RemitentesDto = _mapper.Map<IEnumerable<Remitente>, IEnumerable<RemitenteResponseDto>>(remitentes);
            var response = new ApiResponse<IEnumerable<RemitenteResponseDto>>(RemitentesDto);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var remitente = await _service.GetRemitente(id);
            var remitenteDto = _mapper.Map<Remitente, RemitenteResponseDto>(remitente);
            var response = new ApiResponse<RemitenteResponseDto>(remitenteDto);
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> Post(int id, RemitenteRequestDto remitenteDto)

        {
            var remitente = _mapper.Map<RemitenteRequestDto, Remitente>(remitenteDto);
            await _service.AddRemitente(remitente);
            var remitenteresponseDto = _mapper.Map<Remitente, RemitenteResponseDto>(remitente);
            var response = new ApiResponse<RemitenteResponseDto>(remitenteresponseDto);
            return Ok(response);






        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteRemitente(id);
            var response = new ApiResponse<bool>(true);
            return Ok(response);

        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, RemitenteRequestDto remitenteDto)
        {

            var remitente = _mapper.Map<Remitente>(remitenteDto);
            remitente.Id = id;
            remitente.UpdateAt = DateTime.Now;
            remitente.UpdatedBy = 2;
            _service.UpdateRemitente(remitente);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }



    }
}
