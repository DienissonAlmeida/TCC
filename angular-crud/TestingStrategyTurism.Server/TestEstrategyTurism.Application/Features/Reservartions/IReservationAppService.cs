using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestEstrategyTurism.Domain.Features.Reservations;

namespace TestEstrategyTurism.Application.Features.Reservartions
{
    public interface IReservationAppService
    {
        Task<List<Reservation>> GetReservations();

        Task<Reservation> Post(Reservation reservation);
    }
}
