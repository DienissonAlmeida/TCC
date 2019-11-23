//using eFlight.Application.Features.Flights.Queries;
//using eFlight.Domain;
//using eFlight.Domain.Features.Flights;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace eFlight.Application.Features.Flights.Handlers
//{
//    public class FlightLoadAllHandler : IRequestHandler<FlightLoadAllQuery, List<Flight>>
//    {
//        private readonly IRepositoryBase<Flight> _repository;
//        public FlightLoadAllHandler(IRepositoryBase<Flight> flightRepository)
//        {
//            _repository = flightRepository;
//        }
//        public Task<List<Flight>> Handle(FlightLoadAllQuery request, CancellationToken cancellationToken)
//        {
//            return _repository.GetAll();
//        }
//    }
//}
