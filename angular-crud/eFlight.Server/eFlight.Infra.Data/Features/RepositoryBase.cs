using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using eFlight.Domain;
using eFlight.Data.Context;
using System.Linq;
using eFlight.Domain.Features.Flights;

namespace eFlight.Infra.Data.Features
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected eFlightDbContext _context;

        public RepositoryBase(eFlightDbContext eFlightDbContext)
        {
            _context = eFlightDbContext;
        }
        public async Task<T> Add(T entity)
        {
            var dbEntity = _context.Set<T>().Add(entity).Entity;
            _context.SaveChanges();
            return dbEntity;
        }

        public async Task DeleteById(int id)
        {
            var entity = _context.Set<T>().Find(id);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(int? id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            //_context.Addresses.Update(customer.Address);

             _context.SaveChanges();
            return entity;
        }
    }
}
