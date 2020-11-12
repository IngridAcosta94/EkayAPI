using AutoMapper;
using Ekay.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekay.Api.Controllers
{
	public class CarpetaController : ControllerBase
    {
        private readonly ICarpetaService _service;
        private readonly IMapper _mapper;
        public CarpetaController(ICarpetaService service, IMapper mapper)
        {
            _service = service;
            this._mapper = mapper;

        }
    }
}
