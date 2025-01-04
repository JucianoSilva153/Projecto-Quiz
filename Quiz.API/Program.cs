using FastEndpoints;
using Quiz.API.Repositories;
using Quiz.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistence();
// Adicionar wrappers dos Repositorios
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<KwizzService>();
builder.Services.AddScoped<TopicService>();
builder.Services.AddScoped<PointsService>();

// Configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS middleware
app.UseCors("AllowAllOrigins");

app.UseFastEndpoints();

app.Run();