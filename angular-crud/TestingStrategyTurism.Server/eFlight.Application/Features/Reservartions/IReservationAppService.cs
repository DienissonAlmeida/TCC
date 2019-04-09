using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eFlight.Domain.Features.Reservations;

namespace eFlight.Application.Features.Reservartions
{
    public interface IReservationAppService
    {
        Task<List<Reservation>> GetReservations();

        Task<Reservation> Post(Reservation reservation);
    }
}
