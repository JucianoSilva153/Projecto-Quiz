using System.ComponentModel.DataAnnotations;
using Quiz.Domain.Common;
using Quiz.Domain.Entities.Kwizzes;
using Quiz.Domain.Entities.Users;

namespace Quiz.Domain.Entities.Topics;

public class Topic : Entity
{
    [Required, MaxLength(100)]
    public string Name { get; set; }
    public string? Description { get; set; }

    public User User { get; set; }
    public Guid UserId  { get; set; }

    public IEnumerable<Kwiz> Kwizzes { get; set; }
}