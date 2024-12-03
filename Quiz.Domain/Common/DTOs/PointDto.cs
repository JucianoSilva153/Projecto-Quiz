namespace Quiz.Domain.Common.DTOs;

public record PointDto()
{
    public Guid Id { get; set; }
    public int PointValue { get; set; }
    public Guid QuizId { get; set; }
    public Guid UserId { get; set; }
}