using Quiz.Domain.Common.DTOs;
using Quiz.Domain.Entities.Kwizzes;

namespace Quiz.Persistence.Repositories;

public class KwizRepository : IKwiz
{
    public Task<bool> CreateAsync(Kwiz entity)
    {
        throw new NotImplementedException();
    }

    public Task<QuizDto> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<QuizDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Kwiz entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}