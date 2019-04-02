using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestEstrategyTurism.Domain.Features.Reservations;

namespace TestEstrategyTurism.Domain
{
    public interface IRepositoryBase<T>
    {
        Task<List<T>> GetAll();

        Task<T> Post(T entity);
    }
}
