using System.ComponentModel.DataAnnotations;
using Quiz.Domain.Common;
using Quiz.Domain.Common.DTOs;
using Quiz.Domain.Common.Enum;
using Quiz.Domain.Entities.Users;

namespace Quiz.Domain.Entities.Accounts;

public class Account : Entity
{
    [Required, MaxLength(100)]
    public string UserName { get; set; }
    [Required, MaxLength(100)]
    public string Email { get; set; }

    [Required] public string Password { get; set; } = "000000";
    [Required]
    public AccountType Type { get; set; }
    
    public User User { get; set; }

    public static Account Create(AccountDto dto)
    {
        return new Account
        {
            Type = dto.AccountType,
            Email = dto.Email,
            Password = dto.Password,
            UserName = dto.User,
        };
    }
}