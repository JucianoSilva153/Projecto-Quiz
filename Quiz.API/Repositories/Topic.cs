using System.Collections;
using Quiz.Domain.Common.DTOs;
using Quiz.Domain.Entities.Topics;

namespace Quiz.API.Repositories;

public class TopicService
{
    private readonly ITopic _topicRepository;

    public TopicService(ITopic topicRepository)
    {
        _topicRepository = topicRepository;
    }

    public async Task<bool> CreateAccountAsync(TopicDto topic)
    {
        var topicToAdd = new Topic
        {
            Id = topic.Id,
            UserId = topic.UserId,
            Name = topic.TopicName,
            Description = topic.TopicDescription,
        };
        return await _topicRepository.CreateAsync(topicToAdd);
    }

    public async Task<IEnumerable<TopicDto>> GetAll()
    {
        return await _topicRepository.GetAllAsync();
    }

    public async Task<TopicDto?> GetById(Guid topicId)
    {
        return await _topicRepository.GetByIdAsync(topicId);
    }
}