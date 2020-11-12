using AutoMapper;
using Ekay.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ekay.Api.Controllers
{
	public class AutorController : ControllerBase
    {
        private readonly IAutorService _service;
        private readonly IMapper _mapper;
        public AutorController(IAutorService service, IMapper mapper)
        {
            _service = service;
            this._mapper = mapper;

        }
    }
}
