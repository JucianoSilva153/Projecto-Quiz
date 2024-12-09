using Quiz.Domain.Common;
using Quiz.Domain.Entities.Accounts;
using Quiz.Domain.Entities.Kwizzes;
using Quiz.Domain.Entities.Topics;

namespace Quiz.Domain.Entities.Users;

public class User : Entity
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public Guid AccountId { get; set; }
    public Account Account { get; set; }

    public ICollection<Topic> Topics { get; set; }
    public ICollection<Kwiz> Kwizzes{ get; set; }
}