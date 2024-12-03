namespace Quiz.Domain.Common;

public interface IRepository<T, DTO>
{
    public Task<bool> CreateAsync(T entity);
    public Task<DTO> GetByIdAsync(Guid id);
    public Task<IEnumerable<DTO>> GetAllAsync();
    public Task<bool> UpdateAsync(T entity);
    public Task DeleteAsync(Guid id);
}