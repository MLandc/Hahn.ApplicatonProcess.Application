using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T: class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);
    }
}
