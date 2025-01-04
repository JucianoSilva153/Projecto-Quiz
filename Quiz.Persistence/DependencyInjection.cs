using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Domain.Entities.Accounts;
using Quiz.Domain.Entities.Answers;
using Quiz.Domain.Entities.Kwizzes;
using Quiz.Domain.Entities.Points;
using Quiz.Domain.Entities.Questions;
using Quiz.Domain.Entities.Topics;
using Quiz.Domain.Entities.Users;
using Quiz.Persistence.Context;
using Quiz.Persistence.Repositories;

namespace Quiz.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        
        services.AddDbContext<AppDbContext>(
            options => options.UseMySql(
                "server=localhost;database=kwiz;uid=root;pwd=12345678",
                ServerVersion.Parse("10.4.32")));
        
        services.AddTransient<IUser, UserRepository>();
        services.AddTransient<IAccount, AccountRepository>();
        services.AddTransient<IAnswer, AnswerRepository>();
        services.AddTransient<IKwiz, KwizRepository>();
        services.AddTransient<IPoint, PointRepository>();
        services.AddTransient<IQuestion, QuestionRepository>();
        services.AddTransient<ITopic, TopicRepository>();
        
        
        
        return services;
    }
}
