using Quiz.Domain.Common;
using Quiz.Domain.Common.DTOs;

namespace Domain.Entities;

public interface IAccount : IRepository<Account, AccountDto>
{
}