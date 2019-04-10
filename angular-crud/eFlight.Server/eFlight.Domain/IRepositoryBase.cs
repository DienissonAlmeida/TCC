using System.Collections.Generic;
using System.Threading.Tasks;

namespace eFlight.Domain
{
    public interface IRepositoryBase<T>
    {
        Task<List<T>> GetAll();

        Task<T> Post(T entity);
    }
}
