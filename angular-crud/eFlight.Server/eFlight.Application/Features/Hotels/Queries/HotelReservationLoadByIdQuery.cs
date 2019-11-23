using eFlight.Domain.Features.Hotels;
using MediatR;

namespace eFlight.Application.Features.Hotels.Queries
{
    public class HotelReservationLoadByIdQuery : IRequest<HotelReservation>
    {
        public int HotelReservationId { get; set; }
    }
}
