using System.ComponentModel.DataAnnotations;
using Quiz.Domain.Common;

namespace Quiz.Domain.Entities;

public class Quiz : Entity
{
    [Required, MaxLength(100)]
    public string Name { get; set; }

    public Guid TopicId { get; set; }
    public Topic Topic { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }

    public ICollection<Question> Questions { get; set; }
}