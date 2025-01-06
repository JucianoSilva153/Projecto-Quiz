namespace Quiz.Domain.Common.DTOs;

public record UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}