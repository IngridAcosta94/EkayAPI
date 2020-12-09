using AutoMapper;
using Ekay.Api.Responses;
using Ekay.Domain.DTOs;
using Ekay.Domain.Entities;
using Ekay.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Ekay.Application.Services;
using Ekay.Domain.QueyFilters;

namespace Ekay.Api.Controllers
{
    
	[Route("api/[controller]")]
	[ApiController]
	public class DocumentoController : ControllerBase
	{
        private readonly IDocumentoService _service;
        private readonly IMapper _mapper;
        public DocumentoController(IDocumentoService service, IMapper mapper)
        {
            _service = service;
            this._mapper = mapper;

        }



        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var documentos = _service.GetDocumentos();
                var DocumentosDto = _mapper.Map<IEnumerable<Documento>, IEnumerable<DocumentoResponseDto>>(documentos);
                var response = new ApiResponse<IEnumerable<DocumentoResponseDto>>(DocumentosDto);
                return Ok(response);
            }
            catch(Exception ex)
			{
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> Get([FromQuery] DocumentoQueryFilter filter)
        {
            var documento = await _service.GetDocumento(id);
            var documentoDto = _mapper.Map<Documento, DocumentoResponseDto>(documento);
            var response = new ApiResponse<DocumentoResponseDto>(documentoDto);
            return Ok(response);

        }

        [HttpPost]

        public async Task<IActionResult> Post([FromForm] DocumentoRequestDto documentoDto  )
        {

            
            //Documento documentoA = new Documento();
            try
            {
                var documento = _mapper.Map<DocumentoRequestDto, Documento>(documentoDto);
                await _service.AddDocumento(documento);
                var documentoresponseDto = _mapper.Map<Documento, DocumentoResponseDto>(documento);
                var response = new ApiResponse<DocumentoResponseDto>(documentoresponseDto);

                var filePath = Path.Combine(Environment.CurrentDirectory, "Archivos", documentoDto.ArchivoSubido.FileName);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            await documentoDto.ArchivoSubido.CopyToAsync(stream);
                        }

                        double tamanio = documentoDto.ArchivoSubido.Length;
                        tamanio = tamanio / 1000000;
                        tamanio = Math.Round(tamanio, 2);
                        Path.GetExtension(documentoDto.ArchivoSubido.FileName).Substring(1);
                        documento.NombreArchivo = Path.GetFileNameWithoutExtension( documentoDto.ArchivoSubido.FileName.Trim());
                        documento.Tamanio = tamanio;
                        documento.Ruta = filePath;



                        byte[] bytes = System.IO.File.ReadAllBytes(filePath);
                        string filed = Convert.ToBase64String(bytes);
                        var filePath2 = filePath + Path.GetFileNameWithoutExtension(documentoDto.ArchivoSubido.FileName.Trim()) + ".txt";
                        //var stream2 = System.IO.File.Create(filePath2) ;
                        System.IO.File.WriteAllText(filePath2, filed);
                        documento.RutaBase = filePath2;

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
            await _service.DeleteDocumento(id);
            var response = new ApiResponse<bool>(true);
            return Ok(response);

        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromForm] DocumentoRequestDto documentoDto)
        {
            

            try
			{
                var documento = _mapper.Map<Documento>(documentoDto);
                documento.Id = id;
                
                await _service.UpdateDocumento(documento);

                var documentoresponseDto = _mapper.Map<Documento, DocumentoResponseDto>(documento);
                var response = new ApiResponse<DocumentoResponseDto>(documentoresponseDto);// aqui esta el error
                                                         


                
                return Ok(response);
            }
        catch(Exception ex)
			{
                return BadRequest(ex.Message);
            }

           
        }


       
        
    }
}
