using Quiz.Domain.Common.DTOs;
using Quiz.Domain.Entities.Accounts;
using Quiz.Persistence.Repositories;

namespace Quiz.API.Repositories;

public class AccountService
{
    private readonly IAccount _repository;

    public AccountService(IAccount repository)
    {
        _repository = repository;
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
    
    public async Task<CurrentUser?> LoginAsync(LoginDto access)
    {
        return await _repository.LoginAsync(access);
    }
}