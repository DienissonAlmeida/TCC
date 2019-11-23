using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eFlight.Data.Context;
using eFlight.Domain.Features.Hotels;
using Microsoft.EntityFrameworkCore;

namespace eFlight.Infra.Data.Features.Hotels
{
    public class HotelReservationRepository : RepositoryBase<HotelReservation>, IHotelReservationRepository
    {
        public HotelReservationRepository(eFlightDbContext eFlightDbContext) : base(eFlightDbContext)
        {

        }

        public Task<List<HotelReservation>> GetByHotelId(int hotelId)
        {
            return _context.HotelReservation.Where(x => x.HotelId == hotelId).ToListAsync();
        }
    }
}
