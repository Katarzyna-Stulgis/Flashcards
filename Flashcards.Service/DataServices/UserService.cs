using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models.Entities;

namespace Flashcards.Service.DataServices
{
    public class UserService : RepositoryService<User>
    {
        public UserService(IFlashcardService<User> repository) : base(repository) { }
    }
}
