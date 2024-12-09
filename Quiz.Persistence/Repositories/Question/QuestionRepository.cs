using Quiz.Domain.Common.DTOs;
using Quiz.Domain.Entities.Questions;

namespace Quiz.Persistence.Repositories;

public class QuestionRepository : IQuestion
{
    public Task<bool> CreateAsync(Question entity)
    {
        throw new NotImplementedException();
    }

    public Task<QuestionDto> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<QuestionDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Question entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}