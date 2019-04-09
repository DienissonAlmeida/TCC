using System.Collections.Generic;
using System.Threading.Tasks;
using eFlight.Domain.Features.Cars;

namespace eFlight.Application.Features.Cars
{
    public interface ICarAppService
    {
        Task<List<Car>> GetCars();
    }
}
