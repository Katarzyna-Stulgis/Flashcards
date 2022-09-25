using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models.Entities;

namespace Flashcards.Service.DataServices
{
    public class DeckUserService : RepositoryService<DeckUser>
    {
        public DeckUserService(IFlashcardsRepository<DeckUser> repository) : base(repository) { }
    }
}
