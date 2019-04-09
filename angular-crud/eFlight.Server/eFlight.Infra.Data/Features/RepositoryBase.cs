using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using eFlight.Domain;
using eFlight.Data.Context;

namespace eFlight.Data.Features
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected eFlightDbContext _context;

        public RepositoryBase(eFlightDbContext testingEstrategyTurismDbContext)
        {
            _context = testingEstrategyTurismDbContext;
        }
        public virtual Task<List<T>> GetAll()
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
