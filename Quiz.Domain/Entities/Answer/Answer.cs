using Quiz.Domain.Common;

namespace Quiz.Domain.Entities;

public class Answer : Entity
{
    public string Text { get; set; }
    public bool IsCorrect { get; set; }

    public Guid QuestionId { get; set; }
    public Question Question { get; set; }
}