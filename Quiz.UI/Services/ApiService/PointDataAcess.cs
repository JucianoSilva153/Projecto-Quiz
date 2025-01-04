using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;
using Quiz.Domain.Common.DTOs;
using Quiz.Infrastructure.Common;

namespace Quiz.UI.Services.ApiService;

public class PointDataAcess
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<AccountDataAcess> _logger;

    public PointDataAcess(HttpClient httpClient, ILogger<AccountDataAcess> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<bool> CreateAsync(PointDto point)
    {
        try
        {
            var json = JsonConvert.SerializeObject(point);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            _logger.LogInformation(json.ToString());
            
            var response = await _httpClient.PostAsync("api/point/", content);
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao criar pontuacao: {ex.Message}");
            return false;
        }
    }
    
    public async Task<ApiResponse<IEnumerable<PointDto>>?> GetAll()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/point");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<IEnumerable<PointDto>>>();
            return apiResponse;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return null;
    }
    
}