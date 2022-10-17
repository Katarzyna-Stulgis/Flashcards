using Flashcards.Domain.Models.Entities;

namespace Flashcards.Domain.Interfaces
{
    public interface IShareDeckRepository
    {
        abstract Task<DeckUser> Get(Guid userId, Guid deckId);
        abstract Task<IEnumerable<DeckUser>> GetAllList(Guid userId, bool isEditable);
        abstract Task<DeckUser> AddAsync(DeckUser entity);
        abstract Task<DeckUser> DeleteAsync(DeckUser entity);
    }
}
