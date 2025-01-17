using Quiz.Domain.Common;
using Quiz.Domain.Common.DTOs;

namespace Quiz.Domain.Entities.Kwizzes;

public interface IKwiz : IRepository<Kwiz, KwizDto>
{
    public Task<IEnumerable<KwizDto>> GetUserKwizzes(AccountDto user);

}