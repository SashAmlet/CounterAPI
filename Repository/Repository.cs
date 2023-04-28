using CounterAPI.Context;
using CounterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CounterAPI.Repository
{
    public class Repository<T, _context> : IRepository<T, _context> where T : class, IEntity where _context : DbContext 
    {
        private readonly _context context;
        public Repository(_context context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await context.Set<T>().ToListAsync();

            if (entities == null)
            {
                throw new ArgumentNullException("The GetAll failed, there are no such an entities");
            }
            return entities;
        }        
        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);

            if (entity == null)
            {
                throw new ArgumentNullException("The GetById failed, there is no such entity");
            }
            return entity;
        }
        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, T entity)
        {
            if (id != entity.Id)
                throw new ArgumentException("The id value does not match the entity.Id value");

            context.Set<T>().Update(entity);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TExists(id))
                {
                    throw new ArgumentNullException("The update failed, there is no such entity");
                }
                else
                {
                    throw;
                }
            }
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException("The delete failed, there is no such entity");
            }
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        private bool TExists(int id)
        {
            return (context.Set<T>()?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
