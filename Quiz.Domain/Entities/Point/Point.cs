using System.ComponentModel.DataAnnotations;
using Quiz.Domain.Common;
using Quiz.Domain.Entities.Kwizzes;
using Quiz.Domain.Entities.Users;

namespace Quiz.Domain.Entities.Points;

public class Point : Entity
{
    [Required]
    public int Value { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public Guid QuizId { get; set; }
    public Kwiz Quiz { get; set; }
}