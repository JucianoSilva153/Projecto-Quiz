namespace Quiz.Domain.Common.DTOs;

public record PlayedKwizDto : KwizDto
{
    public int TotalPoints { get; set; }
}