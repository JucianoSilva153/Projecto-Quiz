using System.ComponentModel.DataAnnotations;
using Quiz.Domain.Common.Enum;

namespace Quiz.Domain.Entities;

public class Account
{
    [Required, MaxLength(100)]
    public string UserName { get; set; }
    [Required, MaxLength(100)]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public AccountType Type { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
}