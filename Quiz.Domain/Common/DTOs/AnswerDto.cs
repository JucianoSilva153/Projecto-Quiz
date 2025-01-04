namespace Quiz.Domain.Common.DTOs;

public class AnswerDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid QuestionId { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
}