using Flashcards.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace Flashcards.Dal.Repositories
{
    public class FolderRepository : EFCoreRepository<Folder, DbContext>
    {
        public FolderRepository(DbContext dbContext) : base(dbContext) { }
    }
}
