using Microsoft.EntityFrameworkCore;
using Quiz.Domain.Common.DTOs;
using Quiz.Domain.Common.Enum;
using Quiz.Domain.Entities.Topics;
using Quiz.Persistence.Context;

namespace Quiz.Persistence.Repositories;

public class TopicRepository : ITopic
{
    private AppDbContext _dbContext;

    public TopicRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> CreateAsync(Topic entity)
    {
        if (_dbContext.Topics.Any(t => t.Name == entity.Name))
            return false;
        
        await _dbContext.Topics.AddAsync(entity);
        var result = await _dbContext.SaveChangesAsync();
        if (result <= 0)
            return false;
        return true;
    }

    public async Task<TopicDto?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Topics.Select(topic => new TopicDto
        {
            Id = topic.Id,
            TopicDescription = topic.Description,
            TopicName = topic.Name,
            UserId = topic.UserId,
            TopicQuizzes = _dbContext.Kwizzes.Count(k => k.TopicId == topic.Id)
        }).FirstOrDefaultAsync();
    }
    
    public async Task<IEnumerable<TopicDto>> GetAllAsync()
    {
        var topics = await _dbContext.Topics
            .Select(topic => new
            {
                topic.Id,
                topic.Description,
                topic.Name,
                topic.UserId,
                TopicQuizzes = _dbContext.Kwizzes.Count(k => k.TopicId == topic.Id) // Subconsulta
            })
            .ToListAsync();

        return topics.Select(topic => new TopicDto
        {
            Id = topic.Id,
            TopicDescription = topic.Description,
            TopicName = topic.Name,
            TopicQuizzes = topic.TopicQuizzes,
            UserId = topic.UserId
        });
    }

    public Task<bool> UpdateAsync(Topic entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TopicDto>> GetUserTopics(AccountDto user)
    {
        if (user.AccountType == AccountType.Player)
            return Enumerable.Empty<TopicDto>();
        return (await GetAllAsync()).Where(t => t.UserId == user.UserId);
    }
}