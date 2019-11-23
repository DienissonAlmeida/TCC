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
    public class FlightReservationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FlightReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] FlightReservationRegisterCommand flightRegisterCmd)
        {
            var result = await _mediator.Send(flightRegisterCmd);

            if (result) return Ok(); else return BadRequest();
        }

        public Task<List<FlightReservation>> Get()
        {
            return _mediator.Send(new FlightReservationLoadAllQuery());
        }

        [HttpGet]
        [Route("{id:int}")]
        public Task<FlightReservation> GetBydId(int id)
        {
            return _mediator.Send(new FlightReservationLoadByIdQuery() { FlightReservationId = id });
        }

        [Route("/api/{controller}/flight/{flightId:int}")]
        public Task<List<FlightReservation>> GetByFlightId(int flightId)
        {
            return _mediator.Send(new FlightReservationLoadByFlightIdQuery() { FlightId = flightId });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] FlightReservationDeleteCommand flightDeleteCmd)
        {
            var result = await _mediator.Send(flightDeleteCmd);

            if (result) return Ok(); else return BadRequest();
        }

        [HttpPut]
        //[Route("{flightId:int}")]
        //TODO: testar Update
        public async Task<IActionResult> Update([FromBody] FlightReservationUpdateCommand flightUpdateCmd)
        {
            var result = await _mediator.Send(flightUpdateCmd);

            if (result) return Ok(); else return BadRequest();
        }
    }
}