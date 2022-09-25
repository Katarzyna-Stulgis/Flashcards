using Flashcards.Domain.Exceptions;
using Flashcards.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Dal.Repositories
{
    public abstract class EFCoreRepository<T, TDbContext> : IFlashcardsRepository<T>
        where T : class
        where TDbContext : DbContext
    {
        protected readonly TDbContext _dbContext;

        public EFCoreRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync(Guid userId)
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetAsync(Guid guid)
        {
            var entity = await _dbContext.Set<T>().FindAsync(guid);

            if (entity == null)
            {
                throw new NotFoundException("Not found");
            }
            return entity;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<T> DeleteAsync(Guid guid)
        {
            var entity = await _dbContext.Set<T>().FindAsync(guid);

            if (entity == null)
            {
                throw new NotFoundException("Not found");
            }

            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
        public virtual async Task<T> DeleteIntermediateAsync(Guid guid, Guid guid2)
        {
            return null ;
        }

        public bool ExistsAsync(Guid guid)
        {
            return _dbContext.Set<T>().Find(guid) != null;
        }
    }
}
