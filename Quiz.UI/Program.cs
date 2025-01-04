using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using Quiz.Persistence;
using Quiz.UI;
using MudBlazor.Services;
using Quiz.Domain.Common.DTOs;
using Quiz.UI.Services;
using Quiz.UI.Services.ApiService;
using Quiz.UI.Theme;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7099") });

builder.Services.AddPersistence();
builder.Services.AddMudServices();

//Adicionar servicos da UI
builder.Services.AddScoped<QuizTheme>();
builder.Services.AddScoped<DialogsService>();
builder.Services.AddScoped<DialogService>();
//API Services
builder.Services.AddScoped<AccountDataAcess>();
builder.Services.AddScoped<TopicDataAcess>();
builder.Services.AddScoped<KwizDataAcess>();
builder.Services.AddScoped<PointDataAcess>();
builder.Services.AddScoped<CurrentUser>();
builder.Services.AddBlazoredLocalStorage();


await builder.Build().RunAsync();