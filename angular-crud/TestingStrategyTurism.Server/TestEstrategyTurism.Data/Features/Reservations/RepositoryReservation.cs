using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEstrategyTurism.Data.Context;
using TestEstrategyTurism.Domain.Features.Hotels;
using TestEstrategyTurism.Domain.Features.Reservations;

namespace TestEstrategyTurism.Data.Features.Reservations
{
    public class RepositoryReservation : RepositoryBase<Reservation>
    {
        public RepositoryReservation(TestingEstrategyTurismDbContext testingEstrategyTurismDbContext) : base(testingEstrategyTurismDbContext)
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

