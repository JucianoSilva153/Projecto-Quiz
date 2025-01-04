namespace Quiz.Domain.Common.DTOs;

public record LoginDto()
{
    public string Email { get; set; } = "";
    public string User { get; set; } = "";
    public string Password { get; set; } = "";
}