using System.ComponentModel.DataAnnotations;
using Quiz.Domain.Common;

namespace Domain.Entities;

public class Point : Entity
{
    [Required]
    public int Value { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public Guid QuizId { get; set; }
    public Quiz Quiz { get; set; }
}