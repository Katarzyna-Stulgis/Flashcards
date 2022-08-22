using Flashcards.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace Flashcards.Dal.Repositories
{
    public class FlashcardRepository : EFCoreRepository<Flashcard, DbContext>
    {
        public FlashcardRepository(DbContext dbContext) : base(dbContext) { }
    }
}
