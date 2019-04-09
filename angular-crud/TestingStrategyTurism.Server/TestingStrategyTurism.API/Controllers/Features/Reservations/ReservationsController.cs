using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestEstrategyTurism.Application.Features.Reservartions;
using TestEstrategyTurism.Data.Context;
using RsvRepo = TestEstrategyTurism.Domain.Features.Reservations;
using TestEstrategyTurism.Domain.Features.Reservations;
using TestEstrategyTurism.Data.Features.Reservations;
using TestEstrategyTurism.Domain;
using TestEstrategyTurism.Data.Features;

namespace TestingStrategyTurism.API.Controllers.Features.Reservations
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private IReservationAppService _reservationAppService;
        private IRepositoryBase<Reservation>  _repository;
        private readonly TestingEstrategyTurismDbContext _context;

        public ReservationsController(TestingEstrategyTurismDbContext context)
        {
            _context = context;
            _repository = new RepositoryReservation(_context);
            _reservationAppService = new ReservationAppService(_repository);
        }

        // GET api/cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> Get()
        {
            return await _reservationAppService.GetReservations();
        }

        [HttpPost]
        public async Task<ActionResult<Reservation>> PostAsync([FromBody] Reservation reservation)
        {
            return await _reservationAppService.Post(reservation);
        }
    }
}