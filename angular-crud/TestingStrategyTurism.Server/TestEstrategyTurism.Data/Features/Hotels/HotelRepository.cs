﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestEstrategyTurism.Data.Context;
using TestEstrategyTurism.Domain.Features.Hotels;

namespace TestEstrategyTurism.Data.Features.Hotels
{
    public class HotelRepository : IHotelRepository
    {
        private TestingEstrategyTurismDbContext _context;

        public HotelRepository(TestingEstrategyTurismDbContext testingEstrategyTurismDbContext)
        {
            _context = testingEstrategyTurismDbContext;
        }
        public async Task<List<Hotel>> GetHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        //public async Task<IEnumerable<Hotel>> GetHotelsPerCity(string city)
        //{
        //    return await _context.Hotels.FindAsync(city);
        //}
    }
}
