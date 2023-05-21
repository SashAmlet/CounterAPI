using CounterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CounterAPI.Repository
{
    public interface IRepository<T, _context> where T : class, IEntity where _context: DbContext
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task<bool> DeleteAsync(int id);

    }
}