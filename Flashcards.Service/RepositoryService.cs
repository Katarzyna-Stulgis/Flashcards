using Flashcards.Domain.Interfaces;

namespace Flashcards.Service
{
    public abstract class RepositoryService<T> : IFlashcardService<T>
        where T : class
    {
        protected readonly IFlashcardService<T> _repository;

        public RepositoryService(IFlashcardService<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            return await _repository.AddAsync(entity);
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public virtual async Task<T> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public virtual bool ExistsAsync(int id)
        {
            return _repository.ExistsAsync(id);
        }
    }
}
