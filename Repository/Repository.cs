using CounterAPI.Context;
using CounterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CounterAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly CounterAPIContext context;
        public Repository(CounterAPIContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<T>?> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }
        
        public async Task<T?> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, T entity)
        {
            context.Set<T>().Entry(entity).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TExists(id))
                {
                    throw new Exception("The update failed, there is no such entity");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task Delete(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new Exception("The delete failed, there is no such entity");
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
