using Quiz.Domain.Common.DTOs;
using Quiz.Domain.Entities.Answers;

namespace Quiz.Persistence.Repositories;

public class AnswerRepository : IAnswer
{
    public Task<bool> CreateAsync(Answer entity)
    {
        throw new NotImplementedException();
    }

    public Task<AnswerDto> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AnswerDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Answer entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}