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

        public override Task<Folder> AddAsync(Folder entity)
        {
            entity.FolderId = Guid.NewGuid();
            entity.UserId = new Guid("e22e7101-058e-47cd-8d6f-66633d596fad"); //delete this
            return base.AddAsync(entity);
        }

        public override Task<Folder> GetAsync(Guid guid)
        {
            return base.GetAsync(guid);
        }
    }
}
