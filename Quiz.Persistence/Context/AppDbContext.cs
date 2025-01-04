using Microsoft.EntityFrameworkCore;
using Quiz.Domain.Entities.Accounts;
using Quiz.Domain.Entities.Answers;
using Quiz.Domain.Entities.Kwizzes;
using Quiz.Domain.Entities.Points;
using Quiz.Domain.Entities.Questions;
using Quiz.Domain.Entities.Topics;
using Quiz.Domain.Entities.Users;

namespace Quiz.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Kwiz> Kwizzes { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Point> Points { get; set; }
    public DbSet<Answer> Answers  { get; set; }
}
