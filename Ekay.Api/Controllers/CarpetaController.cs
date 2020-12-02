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
    public class CarpetaController : ControllerBase
    {
        private readonly ICarpetaService _service;
        private readonly IMapper _mapper;
        public CarpetaController(ICarpetaService service, IMapper mapper)
        {
            _service = service;
            this._mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var carpetas = _service.GetCarpetas();
            var CarpetasDto = _mapper.Map<IEnumerable<Carpeta>, IEnumerable<CarpetaResponseDto>>(carpetas);
            var response = new ApiResponse<IEnumerable<CarpetaResponseDto>>(CarpetasDto);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var carpeta = await _service.GetCarpeta(id);
            var carpetaDto = _mapper.Map<Carpeta, CarpetaResponseDto>(carpeta);
            var response = new ApiResponse<CarpetaResponseDto>(carpetaDto);
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> Post(int id, CarpertaRequestDto carpetaDto)

        {
            var carpeta = _mapper.Map<CarpertaRequestDto, Carpeta>(carpetaDto);
            await _service.AddCarpeta(carpeta);
            var carpetaresponseDto = _mapper.Map<Carpeta, CarpetaResponseDto>(carpeta);
            var response = new ApiResponse<CarpetaResponseDto>(carpetaresponseDto);
            return Ok(response);






        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteCarpeta(id);
            var response = new ApiResponse<bool>(true);
            return Ok(response);

        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, CarpertaRequestDto carpetaDto)
        {

            var carpeta = _mapper.Map<Carpeta>(carpetaDto);
            carpeta.Id = id;
            carpeta.UpdateAt = DateTime.Now;
            carpeta.UpdatedBy = 2;
            _service.UpdateCarpeta(carpeta);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }




    }
}
