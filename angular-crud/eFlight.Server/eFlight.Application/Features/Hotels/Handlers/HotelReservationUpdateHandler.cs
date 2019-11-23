using AutoMapper;
using eFlight.Application.Features.Flights.Commands;
using eFlight.Application.Features.Hotels.Commands;
using eFlight.Domain.Features.Flights;
using eFlight.Domain.Features.Hotels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eFlight.Application.Features.Flights.Handlers
{
    public class HotelReservationUpdateHandler : IRequestHandler<HotelReservationUpdateCommand, bool>
    {
        private readonly IHotelReservationRepository _flightRepository;
        private readonly IMapper _mapper;

        public HotelReservationUpdateHandler(IHotelReservationRepository hotelRepository, IMapper mapper)
        {
            _flightRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(HotelReservationUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var flightDb = _flightRepository.GetAll().Result.First(x => x.Id == request.Id);

                _mapper.Map(request, flightDb);

                 _flightRepository.Update(flightDb);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
