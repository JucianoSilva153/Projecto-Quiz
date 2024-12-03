using System.ComponentModel.DataAnnotations;
using Quiz.Domain.Common;

namespace Quiz.Domain.Entities;

public class Topic : Entity
{
    [Required, MaxLength(100)]
    public string Name { get; set; }
    public string? Description { get; set; }

    public User User { get; set; }
    public Guid UserId  { get; set; }
}