using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestEstrategyTurism.Data.Context;
using TestEstrategyTurism.Domain;
using TestEstrategyTurism.Domain.Features;

namespace TestEstrategyTurism.Data.Features.Hotels
{
    public class HotelRepository : IHotelRepository
    {
        private TestingEstrategyTurismDbContext _context;

        public HotelRepository(TestingEstrategyTurismDbContext testingEstrategyTurismDbContext)
        {
            _context = testingEstrategyTurismDbContext;
        }
        public IEnumerable<Hotel> GetHotels()
        {
            return _context.Hotels;
        }
    }
}
