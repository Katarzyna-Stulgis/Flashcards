using Flashcards.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Dal.Repositories
{
    public class DeckFolderRepository : EFCoreRepository<DeckFolder, DbContext>
    {
        public DeckFolderRepository(DbContext dbContext) : base(dbContext) { }
    }
}
