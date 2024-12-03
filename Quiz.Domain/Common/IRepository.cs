namespace Quiz.Domain.Common;

public interface IRepository<T>
{
    public Task<bool> CreateAsync(T entity);
    public Task<T> GetByIdAsync(Guid id);
    public Task<List<T>> GetAllAsync();
    public Task<bool> UpdateAsync(T entity);
    public Task DeleteAsync(Guid id);
}