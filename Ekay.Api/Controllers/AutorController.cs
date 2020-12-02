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
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _service;
        private readonly IMapper _mapper;
        public AutorController(IAutorService service, IMapper mapper)
        {
            _service = service;
            this._mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var autores = _service.GetAutores();
            var AutoresDto = _mapper.Map<IEnumerable<Autor>, IEnumerable<AutorResponseDto>>(autores);
            var response = new ApiResponse<IEnumerable<AutorResponseDto>>(AutoresDto);
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var autor = await _service.GetAutor(id);
            var autorDto = _mapper.Map<Autor, AutorResponseDto>(autor);
            var response = new ApiResponse<AutorResponseDto>(autorDto);
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> Post(int id, AutorRequestDto autorDto)

        {
            var autor = _mapper.Map<AutorRequestDto, Autor>(autorDto);
            await _service.AddAutor(autor);
            var autorresponseDto = _mapper.Map<Autor, AutorResponseDto>(autor);
            var response = new ApiResponse<AutorResponseDto>(autorresponseDto);
            return Ok(response);






        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAutor(id);
            var response = new ApiResponse<bool>(true);
            return Ok(response);

        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, AutorRequestDto autorDto)
        {

            var autor = _mapper.Map<Autor>(autorDto);
            autor.Id = id;
            autor.UpdateAt = DateTime.Now;
            autor.UpdatedBy = 2;
            _service.UpdateAutor(autor);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }

    }
}
