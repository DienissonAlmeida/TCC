using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestEstrategyTurism.Domain.Features.Cars
{
    public interface ICarRepository
    {
        //Task<IEnumerable<Hotel>> GetHotelsPerCity(string city);

        Task<List<Car>> GetCars();

    }
}
