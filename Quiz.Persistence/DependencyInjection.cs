using Microsoft.Extensions.DependencyInjection;
using Quiz.Domain.Entities.Users;
using Quiz.Persistence.Repositories;

namespace Quiz.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IUser, UserRepository>();
        return services;
    }
}
