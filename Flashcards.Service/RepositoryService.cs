using Flashcards.Domain.Interfaces;

namespace Flashcards.Service
{
    public abstract class RepositoryService<T> : IFlashcardService<T>
        where T : class
    {
        protected readonly IFlashcardsRepository<T> _repository;

        public RepositoryService(IFlashcardsRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Guid userId)
        {
            return await _repository.GetAllAsync(userId);
        }

        public virtual async Task<T> GetAsync(Guid guid)
        {
            return await _repository.GetAsync(guid);
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            return await _repository.AddAsync(entity);
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public virtual async Task<T> DeleteAsync(Guid guid)
        {
            return await _repository.DeleteAsync(guid);
        }

        /*        public virtual async Task<T> DeleteIntermediateAsync(Guid guid, Guid guid2)
                {
                    return await _repository.DeleteIntermediateAsync(guid, guid2);
                }*/

        public virtual bool ExistsAsync(Guid guid)
        {
            return _repository.ExistsAsync(guid);
        }
    }
}
