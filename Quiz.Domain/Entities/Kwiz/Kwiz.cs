using System.ComponentModel.DataAnnotations;
using Quiz.Domain.Common;
using Quiz.Domain.Entities.Points;
using Quiz.Domain.Entities.Questions;
using Quiz.Domain.Entities.Topics;
using Quiz.Domain.Entities.Users;

namespace Quiz.Domain.Entities.Kwizzes;

public class Kwiz : Entity
{
    [Required, MaxLength(100)]
    public string Name { get; set; }

    public Guid TopicId { get; set; }
    public Topic Topic { get; set; }
    
    [Required]
    public int MaxPoint { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }

    
    public ICollection<Point> Points { get; set; }
    public ICollection<Question> Questions { get; set; }
}