using eFlight.Application.Features.Cars.Commands;
using eFlight.Application.Features.Cars.Queries;
using eFlight.Domain.Features.Cars;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eCar.API.Controllers.Features.Cars
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarReservationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/Cars
        [HttpGet]
        public Task<List<CarReservation>> Get()
        {
            return _mediator.Send(new CarReservationLoadAllQuery());
        }

        [HttpGet]
        [Route("{id:int}")]
        public Task<CarReservation> GetBydId(int id)
        {
            return _mediator.Send(new CarReservationLoadByIdQuery() { CarReservationId = id });
        }

        [Route("/api/{controller}/car/{carId:int}")]
        public Task<List<CarReservation>> GetByFlightId(int carId)
        {
            return _mediator.Send(new CarReservationLoadByCarIdQuery() { CarId = carId });
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] CarReservationRegisterCommand CarRegisterCmd)
        {
            await _mediator.Send(CarRegisterCmd);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] CarReservationDeleteCommand CarDeleteCmd)
        {
            var result = await _mediator.Send(CarDeleteCmd);

            if (result) return Ok(); else return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(CarReservationUpdateCommand CarUpdateCmd)
        {
            var result = await _mediator.Send(CarUpdateCmd);

            if (result) return Ok(); else return BadRequest();
        }
    }
}