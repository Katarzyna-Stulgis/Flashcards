using Flashcards.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Dal.Repositories
{
    public class DeckRepository : EFCoreRepository<Deck, DbContext>
    {
        public DeckRepository(DbContext dbContext) : base(dbContext) { }

        public override async Task<IEnumerable<Deck>> GetAllAsync()
        {
            var decks = await _dbContext.Set<Deck>()
                .Include(d => d.Flashcards).ToListAsync();

            return decks;
        }

        public async override Task<Deck> GetAsync(Guid guid)
        {
            var deck = await _dbContext.Set<Deck>()
                .Where(d=> d.DeckId == guid)
                .Include(d => d.Flashcards).FirstOrDefaultAsync();

            return deck;
        }
    }
}
