using Flashcards.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Dal.Repositories
{
    public class FlashcardLevelRepository : EFCoreRepository<FlashcardLevel, DbContext>
    {
        public FlashcardLevelRepository(DbContext dbContext) : base(dbContext) { }
    }
}
