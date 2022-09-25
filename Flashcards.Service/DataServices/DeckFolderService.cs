using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Service.DataServices
{
    public class DeckFolderService : RepositoryService<DeckFolder>
    {
        public DeckFolderService(IFlashcardsRepository<DeckFolder> repository) : base(repository) { }
    }
}
