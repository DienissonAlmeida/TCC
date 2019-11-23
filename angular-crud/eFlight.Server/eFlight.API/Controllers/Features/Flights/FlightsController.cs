using eFlight.Application.Features.Flights.Commands;
using eFlight.Application.Features.Flights.Queries;
using eFlight.Domain.Features.Flights;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eFlight.API.Controllers.Features.Flights
{
    [Route("api/[controller]")]
    [ApiController]

    public class FlightsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FlightsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/flights
        [HttpGet]
        public Task<List<Flight>> Get()
        {
            var response =  _mediator.Send(new FlightLoadAllQuery());

            return response;
        }       
    }
}