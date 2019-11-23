using eFlight.Application.Features.TravelPackages.Commands;
using eFlight.Application.Features.TravelPackages.Queries;
using eFlight.Domain.Features.TravelPackages;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eFlight.API.Controllers.Features.TravelPackage
{
    [Route("api/[controller]")]
    [ApiController]
    //TODO: Implementar os testes
    public class TravelPackageReservationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TravelPackageReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/flights
        [HttpGet]
        public Task<List<TravelPackageReservation>> Get()
        {
            return _mediator.Send(new TravelPackageReservationLoadAllQuery());
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] TravelPackageReservationRegisterCommand flightRegisterCmd)
        {
            await _mediator.Send(flightRegisterCmd);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] TravelPackageReservationDeleteCommand flightDeleteCmd)
        {
            var result = await _mediator.Send(flightDeleteCmd);

            if (result) return Ok(); else return BadRequest();
        }

        [HttpPut]
        //TODO: testar Update
        public async Task<IActionResult> Update(TravelPackageReservationUpdateCommand flightUpdateCmd)
        {
            var result = await _mediator.Send(flightUpdateCmd);

            if (result) return Ok(); else return BadRequest();
        }
    }
}