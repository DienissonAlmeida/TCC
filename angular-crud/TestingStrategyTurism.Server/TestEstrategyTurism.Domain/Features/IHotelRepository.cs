using System;
using System.Collections.Generic;
using System.Text;

namespace TestEstrategyTurism.Domain.Features
{
    public interface IHotelRepository
    {
        IEnumerable<Hotel> GetHotels();


    }
}
