using Quiz.Domain.Common.DTOs;
using Quiz.Domain.Entities.Accounts;
using Quiz.Domain.Entities.Users;

namespace Quiz.Persistence.Repositories;

public class AccountRepository : IAccount
{

    private readonly IUser _userRepository;

    public AccountRepository(IUser userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<bool> CreateAsync(Account entity)
    {
        throw new NotImplementedException();
    }

    public Task<AccountDto> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AccountDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Account entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}