using Microsoft.EntityFrameworkCore;
using Quiz.Domain.Common.DTOs;
using Quiz.Domain.Entities.Accounts;
using Quiz.Domain.Entities.Users;
using Quiz.Persistence.Context;

namespace Quiz.Persistence.Repositories;

public class UserRepository : IUser
{
    private readonly AppDbContext _dbContext;
    private readonly IAccount _accountRepository;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> CreateAsync(User entity)
    {
        await _dbContext.Users.AddAsync(entity);
        var userResult = await _dbContext.SaveChangesAsync();

        if (userResult <= 0)
            return false;

        return true;
    }

    public async Task<AccountDto?> GetByIdAsync(Guid id)
    {
        return await _accountRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<AccountDto>> GetAllAsync()
    {
        return await _accountRepository.GetAllAsync();
    }

    public async Task<bool> UpdateAsync(User entity)
    {
        var userToUpdate = await _dbContext.Users.FirstAsync(user => user.Id == entity.Id);

        userToUpdate.Name = entity.Name;
        userToUpdate.Surname = entity.Surname;

        var result = await _dbContext.SaveChangesAsync();
        if (result <= 0)
            return false;
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _accountRepository.DeleteAsync(id);
    }
}