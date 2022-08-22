using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models.Entities;

namespace Flashcards.Service.DataServices
{
    public class FolderService : RepositoryService<Folder>
    {
        public FolderService(IFlashcardService<Folder> repository) : base(repository)
        {
        }
    }
}
