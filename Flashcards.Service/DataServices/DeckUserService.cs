using Flashcards.Domain.Interfaces;
using Flashcards.Domain.Models.Entities;

namespace Flashcards.Service.DataServices
{
    public class DeckUserService : IShareDeckService
    {
        protected readonly IShareDeckRepository _repository;
        public DeckUserService(IShareDeckRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<DeckUser>> GetAllList(Guid userId, bool isEditable)
        {
            return await _repository.GetAllList(userId, isEditable);
        }
        public async Task<DeckUser> AddAsync(DeckUser entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task<DeckUser> DeleteAsync(DeckUser entity)
        {
            return await _repository.DeleteAsync(entity);
        }

        public async Task<DeckUser> Get(Guid userId, Guid deckId)
        {
            return await _repository.Get(userId, deckId);
        }
    }
}
