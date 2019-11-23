using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eFlight.Application.Features.Hotels.Commands;
using eFlight.Application.Features.Hotels.Queries;
using eFlight.Domain.Features.Hotels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFlight.API.Controllers.Features.Hotels
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelReservationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HotelReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/flights
        [HttpGet]
        public Task<List<HotelReservation>> Get()
        {
            return _mediator.Send(new HotelReservationLoadAllQuery());
        }

        [HttpGet]
        [Route("{id:int}")]
        public Task<HotelReservation> GetBydId(int id)
        {
            return _mediator.Send(new HotelReservationLoadByIdQuery() { HotelReservationId = id });
        }

        [Route("/api/{controller}/hotel/{hotelId:int}")]
        public Task<List<HotelReservation>> GetByFlightId(int hotelId)
        {
            return _mediator.Send(new HotelReservationLoadByHotelIdQuery() { HoltelId = hotelId });
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] HotelReservationRegisterCommand flightRegisterCmd)
        {
            await _mediator.Send(flightRegisterCmd);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] HotelReservationDeleteCommand flightDeleteCmd)
        {
            var result = await _mediator.Send(flightDeleteCmd);

            if (result) return Ok(); else return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(HotelReservationUpdateCommand flightUpdateCmd)
        {
            var result = await _mediator.Send(flightUpdateCmd);

            if (result) return Ok(); else return BadRequest();
        }
    }
}