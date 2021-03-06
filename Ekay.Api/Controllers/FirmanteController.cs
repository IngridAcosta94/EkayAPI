using AutoMapper;
using Ekay.Api.Responses;
using Ekay.Domain.DTOs;
using Ekay.Domain.Entities;
using Ekay.Domain.Interfaces;
using Ekay.Domain.QueyFilters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ekay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmanteController : ControllerBase
    {
        private readonly IFirmanteService _service;
        private readonly IMapper _mapper;
        public FirmanteController(IFirmanteService service, IMapper mapper)
        {
            _service = service;
            this._mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FirmanteQueyFilter filter)
        {
            var firmantes = _service.GetFirmantes( filter);
            var FirmantesDto = _mapper.Map<IEnumerable<Firmante>, IEnumerable<FirmanteResponseDto>>(firmantes);
            var response = new ApiResponse<IEnumerable<FirmanteResponseDto>>(FirmantesDto);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var firmante = await _service.GetFirmante(id);
            var firmanteDto = _mapper.Map<Firmante, FirmanteResponseDto>(firmante);
            var response = new ApiResponse<FirmanteResponseDto>(firmanteDto);
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] FirmanteRequestDto firmanteDto)

        {
            try
            {
                var firmante = _mapper.Map<FirmanteRequestDto, Firmante>(firmanteDto);

                await _service.AddFirmante(firmante);
                var firmanteresponseDto = _mapper.Map<Firmante, FirmanteResponseDto>(firmante);
                var response = new ApiResponse<FirmanteResponseDto>(firmanteresponseDto);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }




        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteFirmante(id);
            var response = new ApiResponse<bool>(true);
            return Ok(response);

        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, FirmanteRequestDto firmanteDto)
        {
           // var firmantes = _service.GetFirmante(id);
            //var firman = Firmante.TraerDatos(id);
            
           

            var firmante = _mapper.Map<Firmante>(firmanteDto);


            firmante.Id = id;
            firmante.UpdateAt = DateTime.Now;
            firmante.UpdatedBy = 2;
            _service.UpdateFirmante(firmante);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }






    }
}
