using eFlight.Domain.Features.TravelPackages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eFlight.Domain.Features.Cars
{
    public interface ICarReservationRepository : IRepositoryBase<CarReservation>
    {
        Task<List<CarReservation>> GetByCarId(int carId);
    }
}
