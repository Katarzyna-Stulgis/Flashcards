using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models.Entities;

namespace Flashcards.Service.DataServices
{
    public class DeckFolderService : RepositoryService<DeckFolder>
    {
        public DeckFolderService(IFlashcardsRepository<DeckFolder> repository) : base(repository) { }
    }
}
