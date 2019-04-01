using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestEstrategyTurism.Application.Features.Cars;
using TestEstrategyTurism.Data.Context;
using TestEstrategyTurism.Data.Features;
using TestEstrategyTurism.Data.Features.Cars;
using TestEstrategyTurism.Domain.Features;
using TestEstrategyTurism.Domain.Features.Cars;

namespace TestingStrategyTurism.API.Controllers.Features.Cars
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarAppService _carAppService;
        private IRepositoryBase<Car> _repositoryBase;
        private readonly TestingEstrategyTurismDbContext _context;

        public CarsController(TestingEstrategyTurismDbContext context)
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