using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eFlight.Data.Context;
using eFlight.Domain.Features.Cars;
using Microsoft.EntityFrameworkCore;

namespace eFlight.Infra.Data.Features.Cars
{
    public class CarReservationRepository : RepositoryBase<CarReservation>, ICarReservationRepository
    {
        public CarReservationRepository(eFlightDbContext eFlightDbContext) : base(eFlightDbContext)
        {
        }

        public Task<List<CarReservation>> GetByCarId(int carId)
        {
            return _context.CarReservation.Where(x => x.CarId == carId).ToListAsync();
        }
    }
}
