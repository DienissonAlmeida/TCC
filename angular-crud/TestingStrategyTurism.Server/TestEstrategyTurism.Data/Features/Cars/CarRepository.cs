using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestEstrategyTurism.Data.Context;
using TestEstrategyTurism.Domain.Features.Cars;

namespace TestEstrategyTurism.Data.Features.Hotels
{
    public class CarRepository : ICarRepository
    {
        private TestingEstrategyTurismDbContext _context;

        public CarRepository(TestingEstrategyTurismDbContext testingEstrategyTurismDbContext)
        {
            _context = testingEstrategyTurismDbContext;
        }
        public async Task<List<Car>> GetCars()
        {
            return await _context.Cars.ToListAsync();
        }

        //public async Task<IEnumerable<Hotel>> GetHotelsPerCity(string city)
        //{
        //    return await _context.Hotels.FindAsync(city);
        //}
    }
}
