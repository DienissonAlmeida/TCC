using eFlight.Application;
using eFlight.Application.Features.Hotels.Commands;
using eFlight.Application.Features.Hotels.Queries;
using eFlight.Data.Context;
using eFlight.Domain;
using eFlight.Domain.Features.Hotels;
using eFlight.Infra.Data.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eFlight.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HotelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/flights
        [HttpGet]
        public Task<List<Hotel>> Get()
        {
            return _mediator.Send(new HotelLoadAllQuery());
        }

    }
}
