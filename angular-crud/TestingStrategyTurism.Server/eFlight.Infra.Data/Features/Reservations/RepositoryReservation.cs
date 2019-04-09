using eFlight.Data.Context;
using eFlight.Data.Features;
using eFlight.Domain.Features.Reservations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eFlight.Data.Features.Reservations
{
    public class RepositoryReservation : RepositoryBase<Reservation>
    {
        public RepositoryReservation(eFlightDbContext testingEstrategyTurismDbContext) : base(testingEstrategyTurismDbContext)
        {
        }

        public override Task<List<Reservation>> GetAll()
        {
            var reservations = _context.Reservations
                .Include(rsv => rsv.Hotel)
                .Include(rsv => rsv.Car).
                Include(rsv => rsv.User).AsNoTracking().ToListAsync();

            return reservations;
        }
    }
}

