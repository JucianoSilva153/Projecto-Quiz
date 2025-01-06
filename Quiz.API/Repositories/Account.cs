using Quiz.Domain.Common.DTOs;
using Quiz.Domain.Entities.Accounts;
using Quiz.Domain.Entities.Users;
using Quiz.Persistence.Repositories;

namespace Quiz.API.Repositories;

public class AccountService
{
    private readonly IAccount _repository;
    private readonly IUser _userRepository;

    public AccountService(IAccount repository, IUser userRepository)
    {
        _repository = repository;
        _userRepository = userRepository;
    }

    public async Task<bool> CreateAccountAsync(AccountDto account)
    {
        return await _repository.CreateAsync(Account.Create(account));
    }

    public async Task<IEnumerable<AccountDto>> GetAccounts()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<AccountDto?> GetAccountById(Guid accountId)
    {
        return await _repository.GetByIdAsync(accountId);
    }

    public async Task<bool> EditAccout(AccountDto account)
    {
        var accountToEdit = new Account
        {
            Email = account.Email,
            Id = account.AccountId,
            Password = account.Password,
            Type = account.AccountType,
            UserName = account.User
        };
        
        return await _repository.UpdateAsync(accountToEdit);
    }
    
    public async Task<bool> EditUser(UserDto user)
    {
        var accountToEdit = new User
        {
            Id = user.Id,
            Name = user.Name,
            Surname = user.Surname
        };
        
        return await _userRepository.UpdateAsync(accountToEdit);
    }
    
    public async Task<bool> ChangePassword(AccountDto account)
    {
        var accountToEdit = new Account
        {
            Id = account.AccountId,
            Password = account.Password,
         };
        
        return await _repository.UpdatePasswordAsync(accountToEdit);
    }
    
    public async Task<CurrentUser?> LoginAsync(LoginDto access)
    {
        return await _repository.LoginAsync(access);
    }
}