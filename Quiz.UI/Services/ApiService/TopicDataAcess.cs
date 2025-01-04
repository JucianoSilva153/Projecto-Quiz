using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;
using Quiz.Domain.Common.DTOs;
using Quiz.Infrastructure.Common;

namespace Quiz.UI.Services.ApiService;

public class TopicDataAcess
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<AccountDataAcess> _logger;

    public TopicDataAcess(HttpClient httpClient, ILogger<AccountDataAcess> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
    
    public async Task<bool> CreateAsync(TopicDto topic)
    {
        try
        {
            var json = JsonConvert.SerializeObject(topic);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/topic/", content);
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao criar topico: {ex.Message}");
            return false;
        }
    }
    
    public async Task<ApiResponse<IEnumerable<TopicDto>>?> GetAll()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/topic/");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<IEnumerable<TopicDto>>>();
            return apiResponse;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return null;
    }

}