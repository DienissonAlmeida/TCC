using eFlight.Application.Features.Hotels.Queries;
using eFlight.Domain.Features.Hotels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eFlight.Application.Features.Hotels.Handlers
{
    public class HotelReservationLoadAllHandler : IRequestHandler<HotelReservationLoadAllQuery, List<HotelReservation>>
    {
        private readonly IHotelReservationRepository _repository;
        public HotelReservationLoadAllHandler(IHotelReservationRepository hotelRepository)
        {
            _repository = hotelRepository;
        }

        public Task<List<HotelReservation>> Handle(HotelReservationLoadAllQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAll();
        }
    }

    public class HotelReservationLoadAByIdHandler : IRequestHandler<HotelReservationLoadByIdQuery, HotelReservation>
    {
        private readonly IHotelReservationRepository _repository;
        public HotelReservationLoadAByIdHandler(IHotelReservationRepository hotelRepository)
        {
            _repository = hotelRepository;
        }


        public Task<HotelReservation> Handle(HotelReservationLoadByIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetById(request.HotelReservationId);
        }
    }

    public class HotelReservationLoadAByHotelIdHandler : IRequestHandler<HotelReservationLoadByHotelIdQuery, List<HotelReservation>>
    {
        private readonly IHotelReservationRepository _repository;
        public HotelReservationLoadAByHotelIdHandler(IHotelReservationRepository flightRepository)
        {
            _repository = flightRepository;
        }

        public Task<List<HotelReservation>> Handle(HotelReservationLoadByHotelIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetByHotelId(request.HoltelId);
        }
    }
}
