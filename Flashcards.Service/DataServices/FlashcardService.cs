using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models.Entities;

namespace Flashcards.Service.DataServices
{
    public class FlashcardService : RepositoryService<Flashcard>
    {
        public FlashcardService(IFlashcardsRepository<Flashcard> repository) : base(repository) { }
    }
}
