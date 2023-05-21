using CounterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CounterAPI.Repository
{
    public class ExtendedRepository<T, _context> : Repository<T, _context>, IExtendedRepository<T, _context> where T : class, IEntity, IName where _context : DbContext
    {
        private readonly _context context;
        public ExtendedRepository(_context context) : base(context)
        {
            this.context = context;
        }
        public async Task<int> GetByNameAsync(string name)
        {
            var entity = await context.Set<T>().Where(a=>a.Name == name).Select(a=>a.Id).FirstAsync();

            return entity;
        }
    }
}
