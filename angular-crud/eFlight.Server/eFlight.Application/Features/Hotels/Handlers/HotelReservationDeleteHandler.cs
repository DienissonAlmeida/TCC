using eFlight.Application.Features.Hotels.Commands;
using eFlight.Domain.Features.Hotels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eFlight.Application.Features.Hotels.Handlers
{
    public class HotelReservationDeleteHandler : IRequestHandler<HotelReservationDeleteCommand, bool>
    {
        private readonly IHotelReservationRepository _flightRepository;

        public HotelReservationDeleteHandler(IHotelReservationRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<bool> Handle(HotelReservationDeleteCommand request, CancellationToken cancellationToken)
        {
            var flight = await _flightRepository.GetById(request.HotelReservationId);

            if (flight == null)
                return false;

            await _flightRepository.DeleteById(request.HotelReservationId);
            return true;
        }
    }
}
