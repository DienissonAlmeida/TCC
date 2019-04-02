using System.Collections.Generic;
using System.Threading.Tasks;
using TestEstrategyTurism.Domain;
using TestEstrategyTurism.Domain.Features.Cars;

namespace TestEstrategyTurism.Application.Features.Cars
{
    public class CarAppService : ICarAppService
    {
        private IRepositoryBase<Car> _repositoryBase;

        public CarAppService(IRepositoryBase<Car> carRepository)
        {
            _repositoryBase = carRepository;
        }
        public Task<List<Car>> GetCars()
        {
            return _repositoryBase.GetAll();
        }
    }
}
