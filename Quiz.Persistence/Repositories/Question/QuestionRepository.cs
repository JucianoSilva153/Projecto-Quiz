using Microsoft.EntityFrameworkCore;
using Quiz.Domain.Common.DTOs;
using Quiz.Domain.Entities.Accounts;
using Quiz.Domain.Entities.Questions;
using Quiz.Persistence.Context;

namespace Quiz.Persistence.Repositories;

public class QuestionRepository : IQuestion
{
    private readonly AppDbContext _dbContext;

    public QuestionRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> CreateAsync(Question entity)
    {
        await _dbContext.Questions.AddAsync(entity);
        var result = await _dbContext.SaveChangesAsync();
        if (result <= 0)
            return false;
        return true;
    }

    public async Task<QuestionDto?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Questions.Select(q => new QuestionDto
        {
            Id = q.Id,
            Statement = q.Statement,
            QuizId = q.QuizId
        }).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<QuestionDto>> GetAllAsync()
    {
        return await _dbContext.Questions.Select(q => new QuestionDto
        {
            Id = q.Id,
            Statement = q.Statement,
            QuizId = q.QuizId,
            Answers = q.Answers.Select(a => new AnswerDto
            {
                Id = a.Id,
                QuestionId = q.Id,
                IsCorrect = a.IsCorrect,
                Text = a.Text
            }).ToList()
        }).ToListAsync();
    }

    public Task<bool> UpdateAsync(Question entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}