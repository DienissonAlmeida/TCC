using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using eFlight.Domain.Features.Hotels;

namespace eFlight.Application
{
    public interface IHotelAppService
    {
        //Task<IEnumerable<Hotel>> GetHotelsPerCity(string city);

        Task<List<Hotel>> GetHotels();
    }
}