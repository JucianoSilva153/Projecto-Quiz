using System.ComponentModel.DataAnnotations;
using Quiz.Domain.Common;

namespace Quiz.Domain.Entities;

public class Answer : Entity
{
    [Required]
    public string Text { get; set; }
    [Required]
    public bool IsCorrect { get; set; }

    public Guid QuestionId { get; set; }
    public Question Question { get; set; }
}