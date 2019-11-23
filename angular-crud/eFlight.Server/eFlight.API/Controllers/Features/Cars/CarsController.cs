using eFlight.Application.Features.Cars.Queries;
using eFlight.Domain.Features.Cars;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eFlight.API.Controllers.Features.Cars
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/flights
        [HttpGet]
        public Task<List<Car>> Get()
        {
            return _mediator.Send(new CarLoadAllQuery());
        }
    }
}