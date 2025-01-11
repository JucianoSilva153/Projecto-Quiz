namespace Quiz.Domain.Common.DTOs;

public record KwizDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public int MaxPoint { get; set; }
    public string OwnerName { get; set; }
    public string QuizName { get; set; }
    public string TopicName { get; set; }
    public string TopicDescription { get; set; }
    public DateTime CreatedAt { get; set; }
    public int TimesPlayed { get; set; }
    public IEnumerable<QuestionDto> QuestionDtos { get; set; } = Enumerable.Empty<QuestionDto>();
}