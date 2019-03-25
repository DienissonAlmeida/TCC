using System.Collections.Generic;
using System.Threading.Tasks;
using TestEstrategyTurism.Domain.Features.Hotels;

namespace TestEstrategyTurism.Application
{
    public class HotelAppService : IHotelAppService
    {
        private IHotelRepository _hotelRepository;

        public HotelAppService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public Task<List<Hotel>> GetHotels()
        {
            return _hotelRepository.GetHotels();
        }
        //public async Task<IEnumerable<Hotel>> GetHotelsPerCity(string city)
        //{
        //  return await _hotelRepository.GetHotels(city);

   

    }
}
