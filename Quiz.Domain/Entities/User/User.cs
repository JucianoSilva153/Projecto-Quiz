using Quiz.Domain.Common;

namespace Quiz.Domain.Entities;

public class User : Entity
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public Guid AccountId { get; set; }
    public Account Account { get; set; }

    public ICollection<Topic> Topics { get; set; }
    public ICollection<Quiz> Quizzes{ get; set; }
}