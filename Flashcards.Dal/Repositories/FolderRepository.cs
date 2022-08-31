using Flashcards.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Dal.Repositories
{
    public class FolderRepository : EFCoreRepository<Folder, DbContext>
    {
        public FolderRepository(DbContext dbContext) : base(dbContext) { }

        public override async Task<IEnumerable<Folder>> GetAllAsync()
        {
            var folders = await _dbContext.Set<Folder>()
                .Include(f => f.Decks).ToListAsync();

            return folders;
        }

        public override Task<Folder> GetAsync(Guid guid)
        {
            return base.GetAsync(guid);
        }
    }
}
