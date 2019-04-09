using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestEstrategyTurism.Domain;
using TestEstrategyTurism.Domain.Features;
using TestEstrategyTurism.Domain.Features.Reservations;

namespace TestEstrategyTurism.Application.Features.Reservartions
{
    public class ReservationAppService : IReservationAppService
    {
        private IRepositoryBase<Reservation> _reservationRepository;

        public ReservationAppService(IRepositoryBase<Reservation> repositoryBase)
        {
            _reservationRepository = repositoryBase;
        }

        public Task<List<Reservation>> GetReservations()
        {
            return _reservationRepository.GetAll();
        }

        public Task<Reservation> Post(Reservation reservation)
        {
            return _reservationRepository.Post(reservation);
        }
    }
}
