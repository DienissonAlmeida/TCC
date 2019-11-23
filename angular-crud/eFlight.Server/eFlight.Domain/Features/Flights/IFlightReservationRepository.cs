using System.Collections.Generic;
using System.Threading.Tasks;

namespace eFlight.Domain.Features.Flights
{
    public interface IFlightReservationRepository : IRepositoryBase<FlightReservation>
    {
        Task<List<FlightReservation>> GetAllIncludeCustomers();

        Task<List<FlightReservation>> GetAllIncludeFlight();

        Task<List<FlightReservation>> GetByFlightId(int flightId);
    }
}
