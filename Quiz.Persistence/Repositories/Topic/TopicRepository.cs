using Quiz.Domain.Common.DTOs;
using Quiz.Domain.Entities.Topics;

namespace Quiz.Persistence.Repositories;

public class TopicRepository : ITopic
{
    public Task<bool> CreateAsync(Topic entity)
    {
        throw new NotImplementedException();
    }

    public Task<TopicDto> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TopicDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Topic entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}