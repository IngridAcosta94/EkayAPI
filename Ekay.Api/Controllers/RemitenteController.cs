using AutoMapper;
using Ekay.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekay.Api.Controllers
{
	public class RemitenteController : ControllerBase
    {
        private readonly IRemitenteService _service;
        private readonly IMapper _mapper;
        public RemitenteController(IRemitenteService service, IMapper mapper)
        {
            _service = service;
            this._mapper = mapper;

        }
    }
}
