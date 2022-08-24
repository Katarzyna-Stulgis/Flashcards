﻿namespace Flashcards.Domain.Interfaces
{
    public interface IFlashcardsRepository<T> where T : class
    {
        abstract Task<IEnumerable<T>> GetAllAsync();
        abstract Task<T> GetAsync(Guid guid);
        abstract Task<T> AddAsync(T entity);
        abstract Task<T> UpdateAsync(T entity);
        abstract Task<T> DeleteAsync(Guid guid);
        abstract bool ExistsAsync(Guid guid);
    }
}
