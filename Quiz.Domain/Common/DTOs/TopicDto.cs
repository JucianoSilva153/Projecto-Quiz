namespace Quiz.Domain.Common.DTOs;

public record TopicDto
{
    public Guid Id { get; set; }
    public string TopicName { get; set; }
    public string TopicDescription { get; set; }

    public int TopicQuizzes { get; set; }
}