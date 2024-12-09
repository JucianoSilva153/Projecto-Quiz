using Quiz.Domain.Common;
using Quiz.Domain.Common.DTOs;

namespace Domain.Entities;

public interface IQuestion : IRepository<Question, QuestionDto>
{
    
}