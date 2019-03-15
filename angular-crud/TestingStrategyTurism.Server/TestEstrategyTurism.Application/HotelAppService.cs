using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestEstrategyTurism.Domain;
using TestEstrategyTurism.Domain.Features;

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
