using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestEstrategyTurism.Domain.Features.Hotels
{
    public interface IHotelRepository
    {
        //Task<IEnumerable<Hotel>> GetHotelsPerCity(string city);

        Task<List<Hotel>> GetHotels();

    }
}
