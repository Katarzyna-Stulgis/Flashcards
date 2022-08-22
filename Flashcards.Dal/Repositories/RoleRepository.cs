using Flashcards.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace Flashcards.Dal.Repositories
{
    public class RoleRepository : EFCoreRepository<Role, DbContext>
    {
        public RoleRepository(DbContext dbContext) : base(dbContext) { }
    }
}
