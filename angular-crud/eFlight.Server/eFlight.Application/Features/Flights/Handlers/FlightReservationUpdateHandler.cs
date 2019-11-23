using AutoMapper;
using eFlight.Application.Features.Flights.Commands;
using eFlight.Domain.Features.Flights;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eFlight.Application.Features.Flights.Handlers
{
    public class FlightReservationUpdateHandler : IRequestHandler<FlightReservationUpdateCommand, bool>
    {
        private readonly IFlightReservationRepository _flightRepository;
        private readonly IMapper _mapper;

        public FlightReservationUpdateHandler(IFlightReservationRepository flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(FlightReservationUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var flightDb =  _flightRepository.GetAllIncludeCustomers().Result.First(x => x.Id == request.Id);

                _mapper.Map(request, flightDb);

                 _flightRepository.Update(flightDb);

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }
    }
}
