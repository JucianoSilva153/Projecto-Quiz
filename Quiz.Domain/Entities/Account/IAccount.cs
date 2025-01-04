using Quiz.Domain.Common;
using Quiz.Domain.Common.DTOs;

namespace Quiz.Domain.Entities.Accounts;

public interface IAccount : IRepository<Account, AccountDto>
{
    public Task<CurrentUser?> LoginAsync(LoginDto entity);
}