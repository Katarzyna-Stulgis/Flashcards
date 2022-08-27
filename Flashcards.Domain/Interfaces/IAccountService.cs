using Flashcards.Domain.Models.Entities;

namespace Flashcards.Domain.Interfaces
{
    public interface IAccountService
    {
        abstract Task<User> Register(User entity);
        abstract string GenerateJwt(User entity);
    }
}
