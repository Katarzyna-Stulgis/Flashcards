using Flashcards.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Dal.Repositories
{
    public class DeckRepository : EFCoreRepository<Deck, DbContext>
    {
        public DeckRepository(DbContext dbContext) : base(dbContext) { }

        public override async Task<IEnumerable<Deck>> GetAllAsync(Guid userId)
        {
            var decks = await _dbContext.Set<Deck>()
                .Where(d => d.Users.Any(x => x.UserId == userId))
                .Include(d => d.Flashcards)
                .Include(d => d.DeckFolders)
                .Include(d => d.DeckUsers)
                .ToListAsync();

            return decks;
        }

        public async override Task<Deck> GetAsync(Guid guid)
        {
            var deck = await _dbContext.Set<Deck>()
                .Where(d => d.DeckId == guid)
                .Include(d => d.Flashcards).FirstOrDefaultAsync();

            return deck;
        }

        public async override Task<Deck> UpdateAsync(Deck entity)
        {
            var dbDeck = await GetAsync(entity.DeckId);
            dbDeck.DeckFolders = entity.DeckFolders;

            _dbContext.Entry(dbDeck).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
