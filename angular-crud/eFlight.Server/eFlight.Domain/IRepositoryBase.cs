using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eFlight.Domain.Features.Reservations;

namespace eFlight.Domain
{
    public interface IRepositoryBase<T>
    {
        Task<List<T>> GetAll();

        Task<T> Post(T entity);
    }
}
