using Quiz.Domain.Common;

namespace Quiz.Domain.Entities;

public class Question : Entity
{
    public string Statement { get; set; }
    public int Points { get; set; }

    public Quiz Type { get; set; }
    
    public ICollection<Answer> Answers { get; set; }
}