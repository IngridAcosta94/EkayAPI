﻿using AutoMapper;
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
        public async Task<IActionResult> Get(int id)
        {
            var documento = await _service.GetDocumento(id);
            var documentoDto = _mapper.Map<Documento, DocumentoResponseDto>(documento);
            var response = new ApiResponse<DocumentoResponseDto>(documentoDto);
            return Ok(response);

        }

        [HttpPost]

        public async Task<IActionResult> Post([FromForm] DocumentoRequestDto documentoDto  /*string Correo, string CorreoCop, string UrlFirma*/)

        

        {

           /* List<Documento> documentos = new List<Documento>();
            Documento documentoA = new Documento();
            try
            {
                if (files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        var filePath = "C:\\Users\\ekt\\source\\repos\\Ekay\\Ekay.Api\\Archivos\\" + file.FileName;
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            await file.CopyToAsync(stream);
                        }

                        double tamanio = file.Length;
                        tamanio = tamanio / 1000000;
                        tamanio = Math.Round(tamanio, 2);
                        documentoA.Extension = Path.GetExtension(file.FileName).Substring(1);
                        documentoA.NombreArchivo = Path.GetFileNameWithoutExtension(file.FileName.Trim());
                        documentoA.Tamanio = tamanio;
                        documentoA.Ruta = filePath;



                        byte[] bytes = System.IO.File.ReadAllBytes(filePath);
                        string filed = Convert.ToBase64String(bytes);
                        var filePath2 = "C:\\Users\\ekt\\source\\repos\\Ekay\\Ekay.Api\\Archivos\\" + Path.GetFileNameWithoutExtension(file.FileName.Trim()) + ".txt";
                        //var stream2 = System.IO.File.Create(filePath2) ;
                        System.IO.File.WriteAllText(filePath2, filed);
                        documentoA.RutaBase = filePath2;
                        documentos.Add(documentoA);

                    }



                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }*/

            try
            {


                var documento = _mapper.Map<DocumentoRequestDto, Documento>(documentoDto);
                //documento.Extension = documentoA.Extension;
                //documento.NombreArchivo = documentoA.NombreArchivo;
                //documento.Tamanio = documentoA.Tamanio;
                //documento.Ruta = documentoA.Ruta;
                //documento.RutaBase = documentoA.RutaBase;
                await _service.AddDocumento(documento);
                var documentoresponseDto = _mapper.Map<Documento, DocumentoResponseDto>(documento);
                var response = new ApiResponse<DocumentoResponseDto>(documentoresponseDto);

                return Ok(response);

            }

            catch(Exception ex)
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
        public async Task<IActionResult> Put(int id, [FromForm]List<IFormFile> files)
        {
            DocumentoRequestDto documentoDto = new DocumentoRequestDto();
            List<Documento> documentos = new List<Documento>();
            Documento documentoA = new Documento();
            try
            {
                if (files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        var filePath = "C:\\Users\\ekt\\source\\repos\\Ekay\\Ekay.Api\\Archivos\\" + file.FileName;
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            await file.CopyToAsync(stream);
                        }

                        double tamanio = file.Length;
                        tamanio = tamanio / 1000000;
                        tamanio = Math.Round(tamanio, 2);
                        documentoA.Extension = Path.GetExtension(file.FileName).Substring(1);
                        documentoA.NombreArchivo = Path.GetFileNameWithoutExtension(file.FileName.Trim());
                        documentoA.Tamanio = tamanio;
                        documentoA.Ruta = filePath;



                        byte[] bytes = System.IO.File.ReadAllBytes(filePath);
                        string filed = Convert.ToBase64String(bytes);
                        var filePath2 = "C:\\Users\\ekt\\source\\repos\\Ekay\\Ekay.Api\\Archivos\\" + Path.GetFileNameWithoutExtension(file.FileName.Trim()) + ".txt";
                        //var stream2 = System.IO.File.Create(filePath2) ;
                        System.IO.File.WriteAllText(filePath2, filed);
                        documentoA.RutaBase = filePath2;
                        documentos.Add(documentoA);

                    }



                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            try
			{
                var documento = _mapper.Map<Documento>(documentoDto);
                documento.Id = id;
                /*documento.FechaCreacion = fechaCreacion;
                documento.Contenido = contenido;
                documento.AutorId = autorId;
                documento.CarpetaId = carpetaId;
                documento.RemitenteId = carpetaId;
                documento.TipoDocId = tipoDocId;
                documento.UpdateAt = DateTime.Now;
                documento.UpdatedBy = 2;*/
                documento.Extension = documentoA.Extension;
                documento.NombreArchivo = documentoA.NombreArchivo;
                documento.Tamanio = documentoA.Tamanio;
                documento.Ruta = documentoA.Ruta;
                documento.RutaBase = documentoA.RutaBase;
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
