using System.ComponentModel.DataAnnotations;

namespace Quiz.Domain.Common;

public class Entity
{
    [Key]
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}