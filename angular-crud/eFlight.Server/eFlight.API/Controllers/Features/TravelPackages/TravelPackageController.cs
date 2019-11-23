using eFlight.Application.Features.TravelPackages.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eFlight.API.Controllers.Features.TravelPackages
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelPackageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TravelPackageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/flights
        [HttpGet]
        public Task<List<eFlight.Domain.Features.TravelPackages.TravelPackage>> Get()
        {
            return _mediator.Send(new TravelPackageLoadAllQuery());
        }
    }
}