using Quiz.Domain.Common.Enum;

namespace Quiz.Domain.Common.DTOs;

public class CurrentUser
{
    public AccountDto? MyAccount { get; set; } = null;
    public IEnumerable<AccountDto> Accounts { get; set; } = Enumerable.Empty<AccountDto>();
    
    public IEnumerable<KwizDto> Kwizzes { get; set; } = Enumerable.Empty<KwizDto>();
    public IEnumerable<TopicDto> Topics { get; set; } = Enumerable.Empty<TopicDto>();
    
    public IEnumerable<AccountDto> GetAdmins() => Accounts.Where(a => a.AccountType == AccountType.Admin);
    public IEnumerable<AccountDto> GetCreators() => Accounts.Where(a => a.AccountType == AccountType.Creator);
    public IEnumerable<AccountDto> GetPlayers() => Accounts.Where(a => a.AccountType == AccountType.Player);
}