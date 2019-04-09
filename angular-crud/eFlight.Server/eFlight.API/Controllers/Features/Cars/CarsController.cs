using eFlight.Application.Features.Cars;
using eFlight.Data.Context;
using eFlight.Data.Features;
using eFlight.Domain;
using eFlight.Domain.Features.Cars;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eFlight.API.Controllers.Features.Cars
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarAppService _carAppService;
        private IRepositoryBase<Car> _repositoryBase;
        private readonly eFlightDbContext _context;

        public CarsController(eFlightDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<Car>(_context);
            _carAppService = new CarAppService(_repositoryBase);
        }

        // GET api/cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> Get()
        {
            return await _carAppService.GetCars();
        }
    }
}