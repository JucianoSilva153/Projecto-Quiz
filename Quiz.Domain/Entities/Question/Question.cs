using System.ComponentModel.DataAnnotations;
using Quiz.Domain.Common;

namespace Quiz.Domain.Entities;

public class Question : Entity
{
    [Required]
    public string Statement { get; set; }
    [Required]
    public int Points { get; set; }

    public Guid QuizId { get; set; }
    public Quiz Quiz { get; set; }
    
    
    public ICollection<Answer> Answers { get; set; }
}