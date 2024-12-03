namespace Quiz.Domain.Common.DTOs;

public record QuizDto
{
    public Guid Id { get; set; }
    public string OwnerName { get; set; }
    
    public string QuizName { get; set; }
    
    public string TopicName { get; set; }
    public string TopicDescription { get; set; }

    public int TotalPoints { get; set; }

    public IEnumerable<QuestionDto> QuestionDtos { get; set; }
}