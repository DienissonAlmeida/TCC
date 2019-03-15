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
        public IEnumerable<Hotel> GetHotels(string city)
        {
          return _hotelRepository.GetHotels().Where(x => x.City == city);

        }

        public IEnumerable<Hotel> GetHotels()
        {
            return  _hotelRepository.GetHotels();
        }
    }
}
