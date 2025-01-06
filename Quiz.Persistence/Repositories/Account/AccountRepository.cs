using Microsoft.EntityFrameworkCore;
using Quiz.Domain.Common.DTOs;
using Quiz.Domain.Common.Enum;
using Quiz.Domain.Entities.Accounts;
using Quiz.Domain.Entities.Kwizzes;
using Quiz.Domain.Entities.Topics;
using Quiz.Domain.Entities.Users;
using Quiz.Persistence.Context;

namespace Quiz.Persistence.Repositories;

public class AccountRepository : IAccount
{
    private readonly IUser _userRepository;
    private readonly IKwiz _kwizRepository;
    private readonly ITopic _topicRepository;
    private readonly AppDbContext _dbContext;

    public AccountRepository(IUser userRepository, AppDbContext dbContext, IKwiz kwizRepository, ITopic topicRepository)
    {
        _dbContext = dbContext;
        _kwizRepository = kwizRepository;
        _topicRepository = topicRepository;
        _userRepository = userRepository;
    }


    public async Task<bool> CreateAsync(Account entity)
    {
        //Adiciona a Account
        await _dbContext.Accounts.AddAsync(entity);
        var accountResult = await _dbContext.SaveChangesAsync();
        if (accountResult <= 0)
            return false;

        //Cria o User
        var userToAdd = new User()
        {
            AccountId = entity.Id
        };
        var userResult = await _userRepository.CreateAsync(userToAdd);
        if (!userResult)
            return false;

        return true;
    }

    public async Task<AccountDto?> GetByIdAsync(Guid id)
    {
        var account = await _dbContext.Accounts.AsNoTracking()
            .Include(u => u.User)
            .FirstOrDefaultAsync(account => account.Id == id);
        if (account is null)
            return null;

        var user = await _dbContext.Users.AsNoTracking().FirstAsync(user => user.Id == account.User.Id);

        return new AccountDto
        {
            User = account.UserName,
            AccountType = account.Type,
            Email = account.Email,
            Name = user.Name!,
            Surname = user.Surname!,
            AccountId = account.Id,
            UserId = user.Id
        };
    }

    public async Task<IEnumerable<AccountDto>> GetAllAsync()
    {
        var users = await _dbContext.Users.AsNoTracking().ToListAsync();
        var accounts = await _dbContext.Accounts.AsNoTracking().ToListAsync();

        return from account in accounts
            join user in users on account.Id equals user.AccountId
            select new AccountDto
            {
                User = account.UserName,
                AccountType = account.Type,
                Email = account.Email,
                Name = user.Name,
                Surname = user.Surname,
                AccountId = account.Id,
                UserId = user.Id
            };
    }

    public async Task<bool> UpdateAsync(Account entity)
    {
        var accountToUpdate =
            await _dbContext.Accounts.Include(u => u.User).FirstAsync(account => account.Id == entity.Id);

        accountToUpdate.Email = entity.Email;
        accountToUpdate.UserName = entity.UserName;
        
        var result = await _dbContext.SaveChangesAsync();

        if (result <= 0)
            return false;
        return true;
    }
    
    public async Task<bool> UpdatePasswordAsync(Account entity)
    {
        var accountToUpdate =
            await _dbContext.Accounts.Include(u => u.User).FirstAsync(account => account.Id == entity.Id);

        accountToUpdate.Password = entity.Password;
        
        var result = await _dbContext.SaveChangesAsync();

        if (result <= 0)
            return false;
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var accountToDelete = await _dbContext.Accounts.FirstOrDefaultAsync(account => account.Id == id);
        var userToDelete = await _dbContext.Accounts.FirstOrDefaultAsync(account => account.Id == id);

        if ((accountToDelete is null) || (userToDelete is null))
            return false;

        _dbContext.Remove(userToDelete);
        _dbContext.Remove(accountToDelete);
        var result = await _dbContext.SaveChangesAsync();

        if (result <= 0)
            return false;
        return true;
    }

    public async Task<CurrentUser?> LoginAsync(LoginDto entity)
    {
        var account = await _dbContext.Accounts
            .FirstOrDefaultAsync(u =>
                (u.UserName == entity.User && u.Password == entity.Password) ||
                (u.Email == entity.Email && u.Password == entity.Password));
        if (account is null)
            return null;

        var user = await _dbContext.Users.FirstOrDefaultAsync(a => a.AccountId == account.Id);
        if (user is null)
            return null;


        var currentAccount = new AccountDto
        {
            User = account.UserName,
            AccountType = account.Type,
            Email = account.Email,
            Name = user.Name!,
            Surname = user.Surname!,
            AccountId = account.Id,
            UserId = user.Id,
            Password = account.Password
        };

        return new CurrentUser()
        {
            MyAccount = currentAccount,
            Accounts = await GetUsers(currentAccount),
            Kwizzes = await _kwizRepository.GetUserKwizzes(currentAccount),
            Topics = await _topicRepository.GetUserTopics(currentAccount)
        };
    }

    public async Task<IEnumerable<AccountDto>> GetUsers(AccountDto currentUser)
    {
        if (currentUser.AccountType != AccountType.Admin)
            return Enumerable.Empty<AccountDto>();

        return (await GetAllAsync()).Where(u => u.AccountId != currentUser.AccountId).ToList();
    }
}