using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestEstrategyTurism.Application.Features.Reservartions;
using TestEstrategyTurism.Data.Context;
using TestEstrategyTurism.Data.Features;
using TestEstrategyTurism.Domain.Features;
using TestEstrategyTurism.Domain.Features.Reservations;

namespace TestingStrategyTurism.API.Controllers.Features.Reservations
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private IReservationAppService _reservationAppService;
        private IRepositoryBase<Reservation> _repositoryBase;
        private readonly TestingEstrategyTurismDbContext _context;

        public ReservationsController(TestingEstrategyTurismDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<Reservation>(_context);
            _reservationAppService = new ReservationAppService(_repositoryBase);
        }

        // GET api/cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> Get()
        {
            return await _reservationAppService.GetReservations();
        }
    }
}