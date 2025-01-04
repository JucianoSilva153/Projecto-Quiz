using Microsoft.EntityFrameworkCore;
using Quiz.Domain.Common.DTOs;
using Quiz.Domain.Entities.Points;
using Quiz.Persistence.Context;

namespace Quiz.Persistence.Repositories;

public class PointRepository : IPoint
{
    private AppDbContext _dbContext;

    public PointRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> CreateAsync(Point entity)
    {
        await _dbContext.Points.AddAsync(entity);
        var result = await _dbContext.SaveChangesAsync();

        if (result <= 0)
            return false;
        return true;
    }

    public async Task<PointDto?> GetByIdAsync(Guid id)
    {
        return (await GetAllAsync()).FirstOrDefault(p => p.Id == id);
    }

    public async Task<IEnumerable<PointDto>> GetAllAsync()
    {
        return await _dbContext.Points.Include(u => u.Quiz).Select(p => new PointDto
        {
            Id = p.Id,
            UserId = p.UserId,
            PointValue = p.Value,
            QuizName = p.Quiz.Name,
            PlayedAt = p.CreatedAt,
            QuizId = p.QuizId
        }).ToListAsync();
    }

    public Task<bool> UpdateAsync(Point entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}