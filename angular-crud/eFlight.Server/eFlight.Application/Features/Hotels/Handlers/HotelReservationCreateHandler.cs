using AutoMapper;
using eFlight.Application.Features.Hotels.Commands;
using eFlight.Domain.Features.Hotels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace eFlight.Application.Features.Hotels.Handlers
{
    public class HotelReservationCreateHandler : IRequestHandler<HotelReservationRegisterCommand, bool>
    {
        private readonly IHotelReservationRepository _hotelReservationRepository;
        private readonly IMapper _mapper;

        public HotelReservationCreateHandler(IHotelReservationRepository repository, IMapper mapper)
        {
            _hotelReservationRepository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(HotelReservationRegisterCommand request, CancellationToken cancellationToken)
        {
            //HotelReservation hotelReservation = new HotelReservation()
            //{
            //    InputDate = request.InputDate,
            //    Description = request.Description,
            //    HotelCustomers = request.HotelCustomers,
            //}
            var hotelReservation = _mapper.Map<HotelReservation>(request);

            await _hotelReservationRepository.Add(hotelReservation);

            return true;

        }
    }
}
