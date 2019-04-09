using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using eFlight.Application.Features.Reservartions;
using eFlight.Data.Context;
using RsvRepo = eFlight.Domain.Features.Reservations;
using eFlight.Domain.Features.Reservations;
using eFlight.Data.Features.Reservations;
using eFlight.Domain;
using eFlight.Data.Features;

namespace eFlight.API.Controllers.Features.Reservations
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private IReservationAppService _reservationAppService;
        private IRepositoryBase<Reservation>  _repository;
        private readonly eFlightDbContext _context;

        public ReservationsController(eFlightDbContext context)
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