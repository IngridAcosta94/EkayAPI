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
using System.Text;
using Microsoft.Data.SqlClient;

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
        public async Task<ActionResult> Get( )
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

        public async Task<IActionResult> Post([FromForm] DocumentoRequestDto documentoDto  )
        {

            
            //Documento documentoA = new Documento();
            try
            {
                var documento = _mapper.Map<DocumentoRequestDto, Documento>(documentoDto);
               
                var filePath = Path.Combine(Environment.CurrentDirectory, "Archivos", documentoDto.ArchivoSubido.FileName);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            await documentoDto.ArchivoSubido.CopyToAsync(stream);
                        }

                        double tamanio = documentoDto.ArchivoSubido.Length;
                        tamanio = tamanio / 1000000;
                        tamanio = Math.Round(tamanio, 2);
                        documento.Extension=Path.GetExtension(documentoDto.ArchivoSubido.FileName).Substring(1);
                        documento.NombreArchivo = Path.GetFileNameWithoutExtension( documentoDto.ArchivoSubido.FileName.Trim());
                        documento.Tamanio = tamanio;
                        documento.Ruta = filePath;



                        byte[] bytes = System.IO.File.ReadAllBytes(filePath);
                        string filed = Convert.ToBase64String(bytes);
                        var filePath2 = filePath + Path.GetFileNameWithoutExtension(documentoDto.ArchivoSubido.FileName.Trim()) + ".txt";
                        //var stream2 = System.IO.File.Create(filePath2) ;
                        System.IO.File.WriteAllText(filePath2, filed);
                        documento.RutaBase = filePath2;

                

                await _service.AddDocumento(documento);
                var documentoresponseDto = _mapper.Map<Documento, DocumentoResponseDto>(documento);
                var response = new ApiResponse<DocumentoResponseDto>(documentoresponseDto);

                System.Net.Mail.MailMessage mssg = new System.Net.Mail.MailMessage();
                mssg.To.Add(documentoDto.CorreoF);
                mssg.Subject = "Firma Documento";
                mssg.SubjectEncoding = System.Text.Encoding.UTF8;
                //mssg.Bcc.Add("diegomay100@gmail.com");
                mssg.Body = "https://localhost:44348/Firmar?id= " + documento.Id + "#zoom100";
                mssg.BodyEncoding = System.Text.Encoding.UTF8;
                mssg.IsBodyHtml = true;
                mssg.From = new System.Net.Mail.MailAddress("Ekay.firmar@gmail.com");


                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                cliente.Credentials = new System.Net.NetworkCredential("Ekay.firmar@gmail.com", "Firmando3LFutuR0");
                cliente.Port = 587;
                cliente.EnableSsl = true;
                cliente.Host = "smtp.gmail.com";

                try
                {
                    cliente.Send(mssg);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }


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

        [HttpPut ("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromForm]DocumentoRequestDto documentoDto)
        {
            

            try
            {
                var documento = _mapper.Map<Documento>(documentoDto);
                documento.Id = id;



				string stCadenaConnect = string.Empty;
                stCadenaConnect = "Data Source= LAPTOP-H34OREV3 ;Initial Catalog=Ekay1 ;user id=sa ; password=Ingrid1234;";

                string cValue = "";
                string cValue2 = "";
                string cValue3 = "";
                string stConnection = stCadenaConnect;


               

                string ruta = string.Empty; 
                string nombre = string.Empty;
                string apellido = string.Empty;

                
                using (SqlConnection oConn = new SqlConnection(stConnection))
                    {
                        SqlCommand cmd = new SqlCommand("sp_TraerDocumento", oConn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                        {
                            sqlAdapter.SelectCommand.Parameters.AddWithValue("@id", id);
                        }
                        oConn.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader _Reader = cmd.ExecuteReader();

                        if (_Reader.Read())
                        {
                            cValue = _Reader[0].ToString();
                            cValue2 = _Reader[1].ToString();
                            cValue3 = _Reader[2].ToString();
                        }
                       
                        string respuesta = cValue + "," + cValue2 + "," + cValue3;
                        oConn.Close();
                    char delimitador = ',';
                    string[] valores = respuesta.Split(delimitador);
                     ruta = valores[0].ToString();
                     nombre = valores[1].ToString();
                     apellido = valores[2].ToString();

                }
                               
                //extraer txt
                ruta = ruta.Replace("\\", "/");
                string readText = System.IO.File.ReadAllText(ruta);
                //GENERAR XLM DE FIRMA

                string stXMLBody = string.Empty;
                System.Xml.Linq.XDocument xmlDoc = null;

                try
                {

                    xmlDoc = new System.Xml.Linq.XDocument(new System.Xml.Linq.XDeclaration("1.0", "UTF-8", null),//tipo de escritura de xml UTF8 // aqui hay un error
                        new System.Xml.Linq.XElement("XML", new System.Xml.Linq.XAttribute("version", "1.0"),// titulo del XML 
                                                                                                             //Contenido del XML
                       new System.Xml.Linq.XElement("Certificado", readText),
                       new System.Xml.Linq.XElement("NombreFirmante", nombre),
                       new System.Xml.Linq.XElement("ApellidoFirmante", apellido),
					   new System.Xml.Linq.XElement("Key", documentoDto.Key.FileName),
					   new System.Xml.Linq.XElement("CER", documentoDto.Cer.FileName)

					   )
                        );
                    //creo un archivo de tipo escritura 
                    var wr = new StringWriter(new StringBuilder());
                    xmlDoc.Save(wr);//lo que se escribio arriba lo guardo en un documento xml
                    stXMLBody = wr.ToString();// se crea el archivo de tipo string para devolver el xml

                    var filePath2 = Path.Combine(Environment.CurrentDirectory, "Archivos", "certificado" + DateTime.Now.ToString("hhmm") + ".xml");//creo ruta
                    System.IO.File.WriteAllText(filePath2, stXMLBody);//guardo el archivo en la ruta indicada
                    documentoDto.Certificado = filePath2;//guardo la nueva ruta en el campo Certificado de la Bd
                }
                catch (Exception ex)
                {
                    stXMLBody = ex.Message;

                }

                
                documento.Certificado = documentoDto.Certificado;
                await _service.UpdateDocumento(documento);

                var documentoresponseDto = _mapper.Map<Documento, DocumentoResponseDto>(documento);
                var response = new ApiResponse<DocumentoResponseDto>(documentoresponseDto);// aqui esta el error


                

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
