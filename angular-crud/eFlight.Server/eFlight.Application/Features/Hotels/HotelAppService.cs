using System.Collections.Generic;
using System.Threading.Tasks;
using eFlight.Domain;
using eFlight.Domain.Features;
using eFlight.Domain.Features.Hotels;

namespace eFlight.Application
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
