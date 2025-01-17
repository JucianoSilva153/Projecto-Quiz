using Quiz.Domain.Common;
using Quiz.Domain.Common.DTOs;

namespace Quiz.Domain.Entities.Topics;

public interface ITopic : IRepository<Topic, TopicDto>
{
    public Task<IEnumerable<TopicDto>> GetUserTopics(AccountDto user);
}