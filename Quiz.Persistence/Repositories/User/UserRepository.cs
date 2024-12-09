using Quiz.Domain.Common.DTOs;
using Quiz.Domain.Entities.Accounts;
using Quiz.Domain.Entities.Users;

namespace Quiz.Persistence.Repositories;

public class UserRepository : IUser
{
    public Task<bool> CreateAsync(User entity)
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

    public Task<bool> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}