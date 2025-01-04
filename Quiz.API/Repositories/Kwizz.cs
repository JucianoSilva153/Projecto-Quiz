using Quiz.Domain.Common.DTOs;
using Quiz.Domain.Entities.Answers;
using Quiz.Domain.Entities.Kwizzes;
using Quiz.Domain.Entities.Questions;
using Quiz.Domain.Entities.Topics;
using Quiz.Domain.Entities.Users;

namespace Quiz.API.Repositories;

public class KwizzService
{
    private readonly IKwiz _repository;
    private readonly TopicService _topicRepository;

    public KwizzService(IKwiz repository, ITopic topicRepository, TopicService topicRepository1)
    {
        _repository = repository;
        _topicRepository = topicRepository1;
    }

    public async Task<bool> CreateAsync(KwizDto kwiz)
    {
        var topic = (await _topicRepository.GetAll()).FirstOrDefault(t => t.TopicName == kwiz.TopicName);
        if (topic is null)
            return false;
        
        var kwizToAdd = new Kwiz()
        {
            Id = kwiz.Id,
            UserId = kwiz.UserId,
            Name = kwiz.QuizName,
            Questions = kwiz.QuestionDtos.Select(q => new Question
            {
                Id = q.Id,
                Answers = q.Answers.Select(a => new Answer
                {
                    Id = a.Id,
                    QuestionId = a.QuestionId,
                    Text = a.Text,
                    IsCorrect = a.IsCorrect
                }).ToList(),
                QuizId = q.QuizId,
                Statement = q.Statement
            }).ToList(),
            TopicId = topic.Id,
            MaxPoint = kwiz.MaxPoint,
        };

        return await _repository.CreateAsync(kwizToAdd);
    }

    public async Task<IEnumerable<KwizDto>> GetAll()
    {
        return await _repository.GetAllAsync();
    }
    
    public async Task<KwizDto?> GetById(Guid kwizId)
    {
        return await _repository.GetByIdAsync(kwizId);
    }
}