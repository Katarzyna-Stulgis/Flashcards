using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models.Entities;

namespace Flashcards.Service.DataServices
{
    public class DeckService : RepositoryService<Deck>
    {
        public DeckService(IFlashcardService<Deck> repository) : base(repository) { }
    }
}
