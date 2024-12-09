using System.ComponentModel.DataAnnotations;
using Quiz.Domain.Common;
using Quiz.Domain.Entities.Answers;
using Quiz.Domain.Entities.Kwizzes;

namespace Quiz.Domain.Entities.Questions;

public class Question : Entity
{
    [Required]
    public string Statement { get; set; }

    public Guid QuizId { get; set; }
    public Kwiz Kwiz { get; set; }
    
    public ICollection<Answer> Answers { get; set; }
}