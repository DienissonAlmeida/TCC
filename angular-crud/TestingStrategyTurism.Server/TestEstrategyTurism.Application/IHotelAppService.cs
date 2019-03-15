using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestEstrategyTurism.Domain;

namespace TestEstrategyTurism.Application
{
    public interface IHotelAppService
    {
        IEnumerable<Hotel> GetHotels(string city);

        IEnumerable<Hotel> GetHotels();
    }
}