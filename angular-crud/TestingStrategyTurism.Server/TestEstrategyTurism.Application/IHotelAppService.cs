using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestEstrategyTurism.Domain;

namespace TestEstrategyTurism.Application
{
    public interface IHotelAppService
    {
        //Task<IEnumerable<Hotel>> GetHotelsPerCity(string city);

        Task<List<Hotel>> GetHotels();
    }
}