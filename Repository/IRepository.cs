using CounterAPI.Models;

namespace CounterAPI.Repository
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<IEnumerable<T>?> GetAll();
        Task<T?> GetById(int id);
        Task Add(T entity);
        Task Update(int id, T entity);
        Task Delete(int id);

    }
}