using Flashcards.Domain.Models.Entities;

namespace Flashcards.Domain.Interfaces
{
    public interface IAccountRepository
    {
        abstract Task<User> Register(User entity);
        abstract User GetUserByEmail(string email);
    }
}
