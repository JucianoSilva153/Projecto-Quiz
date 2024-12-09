using System.ComponentModel.DataAnnotations;
using Quiz.Domain.Common;

namespace Domain.Entities;

public class Topic : Entity
{
    [Required, MaxLength(100)]
    public string Name { get; set; }
    public string? Description { get; set; }

    public User User { get; set; }
    public Guid UserId  { get; set; }

    public IEnumerable<Quiz> Quizzes { get; set; }
}