using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestEstrategyTurism.Domain.Features;
using TestEstrategyTurism.Domain.Features.Reservations;

namespace TestEstrategyTurism.Application.Features.Reservartions
{
    public class ReservationAppService : IReservationAppService
    {
        private IRepositoryBase<Reservation> _hotelRepository;

        public ReservationAppService(IRepositoryBase<Reservation> repositoryBase)
        {
            _hotelRepository = repositoryBase;
        }

        public Task<List<Reservation>> GetReservations()
        {
            return _hotelRepository.GetAll();
        }
    }
}
