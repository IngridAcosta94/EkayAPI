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
        public  IActionResult Get([FromQuery] DocumentoQueryFilter filter)
        {
            try
            {
                var documentos = _service.GetDocumentos(filter);
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


        //CREAR CLASE CON CUERPO DE CORREO HTML
        private static string CrearBodyEmail(string sAviso, string sMensaje, string sFirmante)
        {
            string stBody = string.Empty;
            stBody = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
                   " <html xmlns='http://www.w3.org/1999/xhtml'> " +
                   "<head> " +
                   "<meta http-equiv='Content-Type' content='text/html; charset=utf-8' />" +
                   "<title>Avisos</title>" +
                   "</head>" +
                   "<body>" +
                   "<table cellpadding='0' cellspacing='0' border='0' width='500'>" +
                   "<tr>" +
                   "   <td height='30' width='500'><img src='https://i.postimg.cc/s2JNwQdV/Banner-Ekay-2.png'/></td>" +
                   "</tr>" +
                    "<tr>" +
                   "   <td height='30'><font face='Arial' size='2' align='justify'><b>" + sFirmante + "</b></font></td>" +
                   "</tr>" +
                   "<tr>" +
                   "   <td height='30'><font face='Arial' size='2' align='justify'>" + sAviso + "</font></td>" +
                   "</tr>" +
                   "<tr>" +
                   "   <td height='30'><font face='Arial' size='2' color='#FF0000'>" + sMensaje + "</font></td>" +
                   "</tr>" +
                   "<tr>" +
                   "   <td height='30'><font face='Arial' size='2'><b>Att. -El equipo de E-Kay.</b></font></td>" +
                   "</tr>" +
                   "</table>" +
                   "</body>" +
                   "</html>";
            return stBody;
        }//fin:CrearBodyEmail
         //---------------------------------------------------------------------

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

                //MIO

                System.Net.Mail.MailMessage mssg = new System.Net.Mail.MailMessage();
                mssg.To.Add(documentoDto.CorreoF);
                string mensaje = "Usted ha sido referido por una compañia o por un tercero, como el firmante de un documento  en nuestra plataforma. Recuerde tener sus archivos .key y .cer ya que son necesarios para completar dicha firma. Para firmar pulse en el siguiente enlace:";
                mssg.Subject = "Firma de Documento | E-Kay";
                mssg.SubjectEncoding = System.Text.Encoding.UTF8;
                //mssg.Bcc.Add("diegomay100@gmail.com");
                string nombrefirmante = "Estimado(a) " + documentoDto.NombreF + ":";
                mssg.Body = CrearBodyEmail(mensaje, "https://localhost:44348/Firmar?id=" + documento.Id + "#zoom100", nombrefirmante);
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

                //Aqui pongo un if para el put :v

				string stCadenaConnect = string.Empty;
                stCadenaConnect = "Data Source= LAPTOP-H34OREV3 ;Initial Catalog=EkayPRUEBAS ;user id=sa ; password=Ingrid1234;";

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

                //correo confirmar
               /* System.Net.Mail.MailMessage mssg = new System.Net.Mail.MailMessage();
                mssg.To.Add(documentoDto.CorreoF);
                mssg.Subject = "Firma de Documento (completada) | E-Kay";
                mssg.SubjectEncoding = System.Text.Encoding.UTF8;
                string remitente = documentoDto.Correo;
                mssg.Bcc.Add(remitente);
                mssg.IsBodyHtml = true;
                mssg.Body = "El documento "+ documento.NombreArchivo + " ha sido firmado exitosamente por: " + documentoDto.NombreF + ", en fecha: " + DateTime.Now;
                mssg.BodyEncoding = System.Text.Encoding.UTF8;
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
                }*/


                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            

        }
    }
}
