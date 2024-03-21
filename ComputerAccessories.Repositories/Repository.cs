using ComputerAccessories.Data;
using ComputerAccessories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ComputerAccessories.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        public Repository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {

            var entityToDelete = await _dbContext.Set<T>().FindAsync(id);

            _dbContext.Set<T>().Remove(entityToDelete);
            var row = await _dbContext.SaveChangesAsync();
            return row > 0;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await _dbContext.Set<T>().ToListAsync();
            return entities;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            if(entity != null)
            {
                return entity;
            }
            return null;
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            var oldEntity = await _dbContext.Set<T>().FindAsync(id);
            if(oldEntity != null)
            {
                _dbContext.Set<T>().Update(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            return null;
        }
    }
}
