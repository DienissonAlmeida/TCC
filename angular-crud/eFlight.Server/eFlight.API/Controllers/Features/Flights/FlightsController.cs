using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eFlight.Application.Features.Flights;
using eFlight.Data.Context;
using eFlight.Data.Features;
using eFlight.Domain;
using eFlight.Domain.Features.Flights;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFlight.API.Controllers.Features.Flights
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private IFlightAppService _carAppService;
        private IRepositoryBase<Flight> _repositoryBase;
        private readonly eFlightDbContext _context;

        public FlightsController(eFlightDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<Flight>(_context);
            _carAppService = new FlightAppService(_repositoryBase);
        }

        // GET api/cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight>>> Get()
        {
            return await _carAppService.GetFlights();
        }
    }
}