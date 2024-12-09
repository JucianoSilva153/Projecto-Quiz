using Quiz.Domain.Common.Enum;

namespace Quiz.Domain.Common.DTOs;

public record AccountDto()
{
    public Guid Id { get; set; }
    public string User { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public AccountType AccountType { get; set; }
}