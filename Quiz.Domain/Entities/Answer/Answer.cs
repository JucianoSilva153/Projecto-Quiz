using System.ComponentModel.DataAnnotations;
using Quiz.Domain.Common;
using Quiz.Domain.Entities.Questions;

namespace Quiz.Domain.Entities.Answers;

public class Answer : Entity
{
    [Required]
    public string Text { get; set; }
    [Required]
    public bool IsCorrect { get; set; }

    public Guid QuestionId { get; set; }
    public Question Question { get; set; }
}