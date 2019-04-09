using System.Collections.Generic;
using System.Threading.Tasks;
using eFlight.Domain;
using eFlight.Domain.Features.Cars;

namespace eFlight.Application.Features.Cars
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
