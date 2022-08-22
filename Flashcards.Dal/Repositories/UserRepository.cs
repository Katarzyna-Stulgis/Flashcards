using Flashcards.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace Flashcards.Dal.Repositories
{
    public class UserRepository : EFCoreRepository<User, DbContext>
    {
        public UserRepository(DbContext dbContext) : base(dbContext) { }
    }
}
