using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestEstrategyTurism.Domain.Features
{
    public interface IHotelRepository
    {
        //Task<IEnumerable<Hotel>> GetHotelsPerCity(string city);

        Task<List<Hotel>> GetHotels();

    }
}
