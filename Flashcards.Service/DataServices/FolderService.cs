using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models.Entities;

namespace Flashcards.Service.DataServices
{
    public class FolderService : RepositoryService<Folder>
    {
        public FolderService(IFlashcardsRepository<Folder> repository) : base(repository)
        {
        }
    }
}
