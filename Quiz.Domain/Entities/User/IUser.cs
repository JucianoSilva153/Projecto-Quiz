using Quiz.Domain.Common;
using Quiz.Domain.Common.DTOs;

namespace Quiz.Domain.Entities;

public interface IUser : IRepository<User, AccountDto>
{
    
}