using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models.Entities;

namespace Flashcards.Service.DataServices
{
    public class RoleService : RepositoryService<Role>
    {
        public RoleService(IFlashcardService<Role> repository) : base(repository) { }
    }
}
