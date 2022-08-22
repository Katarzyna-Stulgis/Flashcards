using Flashcards.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Dal.Repositories
{
    public class DeckRepository : EFCoreRepository<Deck, DbContext>
    {
        public DeckRepository(DbContext dbContext) : base(dbContext) { }
    }
}
