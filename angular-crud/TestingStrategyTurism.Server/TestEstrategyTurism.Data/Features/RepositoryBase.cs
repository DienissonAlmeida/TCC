using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestEstrategyTurism.Data.Context;
using TestEstrategyTurism.Domain;

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

        public async Task<T> Post(T entity)
        {
            var newCustomer =  _context.Set<T>().Add(entity).Entity;
            await _context.SaveChangesAsync();
            return newCustomer;
        }
    }
}
