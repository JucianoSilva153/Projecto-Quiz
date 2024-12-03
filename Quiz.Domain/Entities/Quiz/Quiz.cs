using Quiz.Domain.Common;

namespace Quiz.Domain.Entities;

public class Quiz : Entity
{
    public string Name { get; set; }

    public Guid TopicId { get; set; }
    public Topic Topic { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }

    public ICollection<Question> Questions { get; set; }
}