using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eFlight.Domain;
using eFlight.Domain.Features;
using eFlight.Domain.Features.Reservations;

namespace eFlight.Application.Features.Reservartions
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
