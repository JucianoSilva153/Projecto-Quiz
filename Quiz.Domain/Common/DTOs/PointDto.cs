namespace Quiz.Domain.Common.DTOs;

public record PointDto()
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int PointValue { get; set; }
    public Guid QuizId { get; set; }
    public string QuizName { get; set; } = "";
    public DateTime PlayedAt  { get; set; }
    public Guid UserId { get; set; }
}