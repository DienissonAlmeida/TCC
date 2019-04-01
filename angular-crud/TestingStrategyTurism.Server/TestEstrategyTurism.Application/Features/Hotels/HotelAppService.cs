using System.Collections.Generic;
using System.Threading.Tasks;
using TestEstrategyTurism.Domain.Features;
using TestEstrategyTurism.Domain.Features.Hotels;

namespace TestEstrategyTurism.Application
{
    public class HotelAppService : IHotelAppService
    {
        private IRepositoryBase<Hotel> _hotelRepository;

        public HotelAppService(IRepositoryBase<Hotel> hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public Task<List<Hotel>> GetHotels()
        {
            return _hotelRepository.GetAll();
        }  
    }
}
