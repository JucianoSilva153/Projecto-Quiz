using Quiz.Domain.Common;
using Quiz.Domain.Common.DTOs;

namespace Domain.Entities;

public interface IQuiz : IRepository<Quiz, QuizDto>
{
    
}