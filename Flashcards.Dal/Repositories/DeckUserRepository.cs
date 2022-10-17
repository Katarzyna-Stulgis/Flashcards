using Flashcards.Domain.Exceptions;
using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Dal.Repositories
{
    public class DeckUserRepository<TDbContext> : IShareDeckRepository
         where TDbContext : DbContext
    {
        protected readonly TDbContext _dbContext;
        public DeckUserRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<DeckUser> Get(Guid userId, Guid deckId)
        {
            var entity = await _dbContext.Set<DeckUser>()
                .Where(x => x.UserId == userId && x.DeckId == deckId)
                .FirstOrDefaultAsync();

            return entity;
        }
        public async Task<IEnumerable<DeckUser>> GetAllList(Guid userId, bool isEditable)
        {
            var entity = await _dbContext.Set<DeckUser>()
                .Where(x => ((bool)x.IsEditable) == ((bool)isEditable) && x.UserId == userId)
                .ToListAsync();

            if (entity == null)
            {
                throw new NotFoundException("Not found");
            }
            return entity;
        }

        public async Task<DeckUser> AddAsync(DeckUser entity)
        {
            _dbContext.Set<DeckUser>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<DeckUser> DeleteAsync(DeckUser entity)
        {
            _dbContext.Set<DeckUser>().Remove(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
