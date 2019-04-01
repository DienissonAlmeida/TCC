using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestEstrategyTurism.Data.Context;
using TestEstrategyTurism.Domain.Features;

namespace TestEstrategyTurism.Data.Features
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private TestingEstrategyTurismDbContext _context;

        public RepositoryBase(TestingEstrategyTurismDbContext testingEstrategyTurismDbContext)
        {
            _context = testingEstrategyTurismDbContext;
        }
        public Task<List<T>> GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToListAsync();
        }
    }
}
