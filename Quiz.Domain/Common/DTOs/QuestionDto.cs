namespace Quiz.Domain.Common.DTOs;

public record QuestionDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid QuizId { get; set; }
    
    public string Statement { get; set; }
    public IEnumerable<AnswerDto> Answers { get; set; } = Enumerable.Empty<AnswerDto>();
}