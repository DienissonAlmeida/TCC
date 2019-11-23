using System.Collections.Generic;
using System.Threading.Tasks;

namespace eFlight.Domain.Features.Hotels
{
    public interface IHotelReservationRepository : IRepositoryBase<HotelReservation>
    {
        Task<List<HotelReservation>> GetByHotelId(int hotelId);
    }
}
