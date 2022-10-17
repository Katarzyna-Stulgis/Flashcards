using Flashcards.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Dal.Repositories
{
    public class FolderRepository : EFCoreRepository<Folder, DbContext>
    {
        public FolderRepository(DbContext dbContext) : base(dbContext) { }

        public override async Task<Folder> GetAsync(Guid guid)
        {
            var folder = await _dbContext.Set<Folder>()
                .Where(f => f.FolderId == guid)
                .Include(f => f.Decks)
                .FirstOrDefaultAsync();
            return folder;
        }

        public override async Task<IEnumerable<Folder>> GetAllAsync(Guid userId)
        {
            var folders = await _dbContext.Set<Folder>()
                .Where(f => f.UserId == userId)
                .Include(f => f.Decks).ToListAsync();

            return folders;
        }

        public override Task<Folder> AddAsync(Folder entity)
        {
            entity.FolderId = Guid.NewGuid();
            return base.AddAsync(entity);
        }

        public override async Task<Folder> UpdateAsync(Folder entity)
        {
            if (entity.Decks != null)
            {
                var decks = await _dbContext.Set<DeckFolder>()
                    .Where(df => df.FolderId == entity.FolderId)
                    .ToListAsync();

                decks.ForEach(element =>
                {
                    _dbContext.Set<DeckFolder>().Remove(element);
                });
                await _dbContext.SaveChangesAsync();

                foreach (var deck in entity.Decks)
                {
                    var df = new DeckFolder()
                    {
                        DeckId = deck.DeckId,
                        FolderId = entity.FolderId,
                    };

                    _dbContext.Set<DeckFolder>().Add(df);
                    await _dbContext.SaveChangesAsync();
                }
            }

            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return entity;
        }

    }
}
