using System.Collections.Generic;
using System.Threading.Tasks;

namespace BikeManagement.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);

        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);

    }
}
