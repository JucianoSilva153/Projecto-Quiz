using Quiz.Domain.Common.DTOs;
using Quiz.Domain.Entities.Points;

namespace Quiz.Persistence.Repositories;

public class PointRepository : IPoint
{
    public Task<bool> CreateAsync(Point entity)
    {
        throw new NotImplementedException();
    }

    public Task<PointDto> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PointDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Point entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}