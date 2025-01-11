using Microsoft.EntityFrameworkCore;
using Quiz.Domain.Common.DTOs;
using Quiz.Domain.Common.Enum;
using Quiz.Domain.Entities.Kwizzes;
using Quiz.Domain.Entities.Points;
using Quiz.Domain.Entities.Questions;
using Quiz.Persistence.Context;

namespace Quiz.Persistence.Repositories;

public class KwizRepository : IKwiz
{
    private IQuestion _questionRepository;
    private AppDbContext _dbContext;

    public KwizRepository(IQuestion questionRepository, AppDbContext dbContext)
    {
        _questionRepository = questionRepository;
        _dbContext = dbContext;
    }

    public async Task<bool> CreateAsync(Kwiz entity)
    {
        await _dbContext.Kwizzes.AddAsync(entity);
        var result = await _dbContext.SaveChangesAsync();
        if (result <= 0)
            return false;
        return true;
    }

    public async Task<KwizDto?> GetByIdAsync(Guid id)
    {
        return (await GetAllAsync()).FirstOrDefault(k => k.Id == id);
    }

    public async Task<IEnumerable<KwizDto>> GetAllAsync()
    {
        var kwizDtos = await _dbContext.Kwizzes
            .Include(k => k.User)
            .Select(k => new KwizDto
            {
                Id = k.Id,
                OwnerName = k.User.Name ?? "",
                QuizName = k.Name,
                TopicName = k.Topic.Name,
                MaxPoint = k.MaxPoint,
                UserId = k.UserId,
                CreatedAt = k.CreatedAt,
                TimesPlayed = _dbContext.Points.Count(p => p.QuizId == k.Id),
                TopicDescription = k.Topic.Description ?? "",
                QuestionDtos = k.Questions.Select(q => new QuestionDto
                {
                    Id = q.Id,
                    QuizId = q.QuizId,
                    Statement = q.Statement,
                    Answers = q.Answers.Select(a => new AnswerDto
                    {
                        Id = a.Id,
                        QuestionId = a.QuestionId,
                        Text = a.Text,
                        IsCorrect = a.IsCorrect
                    }).ToList()
                }).ToList()
            })
            .ToListAsync();

        return kwizDtos.AsEnumerable();
    }
    
    public Task<bool> UpdateAsync(Kwiz entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<KwizDto>> GetUserKwizzes(AccountDto user)
    {
        if (user.AccountType == AccountType.Player)
            return Enumerable.Empty<KwizDto>();
        return (await GetAllAsync()).Where(k => k.UserId == user.UserId);
    }
}