using System.ComponentModel.DataAnnotations;

namespace Quiz.Domain.Common;

public class Entity
{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}