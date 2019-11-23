using eFlight.Application.Features.Cars.Queries;
using eFlight.Domain;
using eFlight.Domain.Features.Cars;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eFlight.Application.Features.Cars.Handlers
{
    public class CarLoadAllHandler : IRequestHandler<CarLoadAllQuery, List<Car>>
    {
        private readonly IRepositoryBase<Car> _repository;
        public CarLoadAllHandler(IRepositoryBase<Car> _carRepository)
        {
            _repository = _carRepository;
        }

        public Task<List<Car>> Handle(CarLoadAllQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAll(); ;
        }
    }
}
