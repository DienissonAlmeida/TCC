using eFlight.Domain;
using eFlight.Domain.Features.Flights;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eFlight.Application.Features.Flights
{
    public class FlightAppService : IFlightAppService
    {
        private IRepositoryBase<Flight> _repositoryBase;

        public FlightAppService(IRepositoryBase<Flight> flightRepository)
        {
            _repositoryBase = flightRepository;
        }
        public Task<List<Flight>> GetFlights()
        {
            return _repositoryBase.GetAll();
        }
    }
}
