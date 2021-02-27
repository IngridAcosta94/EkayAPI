﻿using AutoMapper;
using Ekay.Api.Responses;
using Ekay.Domain.DTOs;
using Ekay.Domain.Entities;
using Ekay.Domain.Interfaces;
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
        public async Task<IActionResult> Get()
        {
            var firmantes = _service.GetFirmantes();
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

                System.Net.Mail.MailMessage mssg = new System.Net.Mail.MailMessage();
                mssg.To.Add(firmanteDto.CorreoF);
                mssg.Subject = "Firma Documento";
                mssg.SubjectEncoding = System.Text.Encoding.UTF8;
                //mssg.Bcc.Add("diegomay100@gmail.com");
                mssg.Body = "https://localhost:44348/Firmar?id=1"+"#zoom100";
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
