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
            //Original

            try
			{
                var documento = _mapper.Map<Documento>(documentoDto);
                documento.Id = id;
                documento.CarpetaId = 2;
                documento.AutorId = 1;
                documento.FirmanteId = 1;
                documento.TipoDocId = 2;
                documento.RemitenteId = 1;



                string stCadenaConnect = string.Empty;
                stCadenaConnect = "Data Source= LAPTOP-H34OREV3 ;Initial Catalog=Ekay1 ;user id=sa ; password=Ingrid1234;";

                string cValue = "";//aqui falla--Solucionado
                string cValue2 = "";
                string cValue3 = "";
                string stConnection = stCadenaConnect;


                Microsoft.Data.SqlClient.SqlConnection _Conexion = new Microsoft.Data.SqlClient.SqlConnection(stConnection);
                /*la sentencia no se ejecuta debido a la forma por la que se envian los datos 
                 desde la pagina web se intento forzando el linq con Tolist pero no funcionó// tratar con convertir la sentencia en un proceso almacenado*/

                var _CadenaSql = ("select Documento.RutaBase, Firmante.Nombre, Firmante.Apellido from Firmante inner join Documento on Firmante.Id = Documento.FirmanteId where Documento.Id = @cValue");
                Microsoft.Data.SqlClient.SqlCommand _Command = new Microsoft.Data.SqlClient.SqlCommand(_CadenaSql, _Conexion);
                _Command.Parameters.AddWithValue("@cValue", id);
                _Conexion.Open();

                Microsoft.Data.SqlClient.SqlDataReader _Reader = _Command.ExecuteReader();

                if (_Reader.Read())
                {
                    cValue = _Reader[0].ToString();
                    cValue2 = _Reader[1].ToString();
                    cValue3 = _Reader[2].ToString();
                }
                string respuesta = cValue + "," + cValue2 + "," + cValue3;

                char delimitador = ',';
                string[] valores = respuesta.Split(delimitador);

                string ruta = valores[0].ToString();
                string nombre = valores[1].ToString();
                string apellido = valores[2].ToString();


                //extraer txt
                ruta = ruta.Replace("\\", "/");
                string readText = System.IO.File.ReadAllText(ruta);
                //GENERAR XLM DE FIRMA

                string stXMLBody = string.Empty;
                System.Xml.Linq.XDocument xmlDoc = null;

                try
                {

                    xmlDoc = new System.Xml.Linq.XDocument(new System.Xml.Linq.XDeclaration("1.0", "UTF-8", null),//tipo de escritura de xml UTF8
                        new System.Xml.Linq.XElement("XML", new System.Xml.Linq.XAttribute("version", "1.0"),// titulo del XML 
                                                                                                             //Contenido del XML
                       new System.Xml.Linq.XElement("Certificado", readText),
                       new System.Xml.Linq.XElement("NombreFirmante", nombre),
                       new System.Xml.Linq.XElement("ApellidoFirmante", apellido),
                       new System.Xml.Linq.XElement("Key", "key"),
                       new System.Xml.Linq.XElement("CER", "cer")

                       )
                        );
                    //creo un archivo de tipo escritura 
                    var wr = new StringWriter(new StringBuilder());
                    xmlDoc.Save(wr);//lo que se escribio arriba lo guardo en un documento xml
                    stXMLBody = wr.ToString();// se crea el archivo de tipo string para devolver el xml

                    var filePath2 = Path.Combine(Environment.CurrentDirectory, "Archivos", "certificado" + DateTime.Now.ToString("hhmm") + ".xml");//creo ruta
                    System.IO.File.WriteAllText(filePath2, stXMLBody);//guardo el archivo en la ruta indicada
                    documento.Certificado = filePath2;//guardo la nueva ruta en el campo Certificado de la Bd
                }
                catch (Exception ex)
                {
                    stXMLBody = ex.Message;

                }

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
