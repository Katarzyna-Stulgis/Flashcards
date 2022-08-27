using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Flashcards.Dal.Repositories
{
    public class UserRepository<TDbContext> : IAccountRepository
        where TDbContext : DbContext
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly TDbContext _dbContext;

        public UserRepository(IPasswordHasher<User> passwordHasher, TDbContext dbContext)
        {
            _passwordHasher = passwordHasher;
            _dbContext = dbContext;
        }

        public async Task<User> Register(User entity)
        {
            var newUser = new User()
            {
                UserId = Guid.NewGuid(),
                Name = entity.Name,
                Email = entity.Email
            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, entity.Password);
            newUser.Password = hashedPassword;

            _dbContext.Set<User>().Add(newUser);

            await _dbContext.SaveChangesAsync();

            return newUser;
        }

        public User GetUserByEmail(string email)
        {
            return _dbContext.Set<User>().FirstOrDefault(u => u.Email == email);
        }
    }
}
