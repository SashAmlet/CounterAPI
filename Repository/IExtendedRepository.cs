using CounterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CounterAPI.Repository
{
    public interface IExtendedRepository<T, _context>: IRepository<T,_context> where T : class, IEntity, IName where _context : DbContext
    {
        Task<int> GetByNameAsync(string name);
    }
}
