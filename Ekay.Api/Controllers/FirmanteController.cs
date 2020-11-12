using AutoMapper;
using Ekay.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekay.Api.Controllers
{
	public class FirmanteController : ControllerBase
    {
        private readonly IFirmanteService _service;
        private readonly IMapper _mapper;
        public FirmanteController(IFirmanteService service, IMapper mapper)
        {
            _service = service;
            this._mapper = mapper;

        }
    }
}
