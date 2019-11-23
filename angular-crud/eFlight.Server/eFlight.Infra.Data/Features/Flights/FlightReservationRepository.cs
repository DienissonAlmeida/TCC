using eFlight.Data.Context;
using eFlight.Domain.Features.Flights;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFlight.Infra.Data.Features.Flights
{
    public class FlightReservationRepository : RepositoryBase<FlightReservation>, IFlightReservationRepository
    {
        public FlightReservationRepository(eFlightDbContext eFlightDbContext) : base(eFlightDbContext)
        {       }

        public Task<List<FlightReservation>> GetAllIncludeFlight()
        {
            return _context.FlightReservation.Include(x => x.Flight).ToListAsync();
        }

        public Task<List<FlightReservation>> GetAllIncludeCustomers()
        {
            return _context.FlightReservation.Include(x => x.FlightReservationCustomers).ToListAsync();
        }

        public Task<List<FlightReservation>> GetByFlightId(int flightId)
        {
            return _context.FlightReservation.Where(x => x.FlightId == flightId).ToListAsync();
        }
    }
}