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
            var documentos =  _service.GetDocumentos();
            var DocumentosDto = _mapper.Map<IEnumerable<Documento>, IEnumerable<DocumentoResponseDto>>(documentos);
            var response = new ApiResponse<IEnumerable<DocumentoResponseDto>>(DocumentosDto);
            return Ok(response);
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
        public async Task<IActionResult> Post(DocumentoRequestDto documentoDto ,[FromForm] List<IFormFile> files  /*string Correo, string CorreoCop, string UrlFirma*/)

        {
            //List < Documento > documentos = new List<Documento>();

            /* System.Net.Mail.MailMessage mssg = new System.Net.Mail.MailMessage();
			 mssg.To.Add(Correo);
			 mssg.Subject = "Firma Documento";
			 mssg.SubjectEncoding = System.Text.Encoding.UTF8;
			 mssg.Bcc.Add(CorreoCop);//para que le llegue copia a alguien
			 mssg.Body = "Ingresa a siguiente enlace para firmar " + UrlFirma;
			 mssg.BodyEncoding = System.Text.Encoding.UTF8;
			 mssg.IsBodyHtml = true;
			 mssg.From = new System.Net.Mail.MailAddress("ingridacosta322@gmail.com");


			 System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
			 cliente.Credentials = new System.Net.NetworkCredential("ingridacosta322@gmail.com", "ingrid1234");//remitente
			 cliente.Port = 587;
			 cliente.EnableSsl = true;
			 cliente.Host = "smtp.gmail.com";
			 try
			 {

				 cliente.Send(mssg);

				 // MessageBox.Show("Cita Cancelada y se envio correo de notificacion.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
			 }
			 catch (Exception ex)
			 {
				 return Ok(ex.Message);
				 // MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			 }*/

            /*try
			{


               if( files.Count > 0  )
                {
                    foreach(var file in files)
					{
                        var filePath = "C:\\Users\\ekt\\source\\repos\\Ekay\\Ekay.Api" + file.FileName;
                        using(var stream = System.IO.File.Create(filePath))
						{
							await file.CopyToAsync(stream);
						}

                        double tamanio = file.Length;
                        tamanio = tamanio / 1000000;
                        tamanio = Math.Round(tamanio, 2);
                        Documento documentoA = new Documento();
                        documentoA.Extension = Path.GetExtension(file.FileName).Substring(1);
                        documentoA.NombreArchivo = Path.GetFileNameWithoutExtension(file.FileName);
                        documentoA.Tamanio = tamanio;
                        documentoA.Ruta = filePath;
                        documentos.Add(documentoA);

                    }				  
                
                
                
                
                }



			}
            catch(Exception ex)
			{
                return BadRequest(ex.Message);
			}*/

            //DocumentoRequestDto documentoDto = new DocumentoRequestDto();
            

            var documento = _mapper.Map<DocumentoRequestDto, Documento>(documentoDto);
            await _service.AddDocumento(documento);
            var documentoresponseDto = _mapper.Map<Documento, DocumentoResponseDto>(documento);
            var response = new ApiResponse<DocumentoResponseDto>(documentoresponseDto);

            return Ok(response);


           




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
