using System.Collections.Generic;
using System.Threading.Tasks;
using TestEstrategyTurism.Domain.Features.Cars;

namespace TestEstrategyTurism.Application.Features.Cars
{
    public interface ICarAppService
    {
        Task<List<Car>> GetCars();
    }
}
