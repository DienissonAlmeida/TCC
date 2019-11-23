using eFlight.Domain.Features.Hotels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace eFlight.Application.Features.Hotels.Queries
{
    public class HotelReservationLoadByHotelIdQuery : IRequest<List<HotelReservation>>
    {
        public int HoltelId { get; set; }
    }
}
