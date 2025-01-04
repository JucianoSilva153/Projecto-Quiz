using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;
using Quiz.Domain.Common.DTOs;
using Quiz.Infrastructure.Common;

namespace Quiz.UI.Services.ApiService;

public class KwizDataAcess
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<AccountDataAcess> _logger;

    public KwizDataAcess(HttpClient httpClient, ILogger<AccountDataAcess> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
    
    public async Task<bool> CreateAsync(KwizDto kwiz)
    {
        try
        {
            var json = JsonConvert.SerializeObject(kwiz);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/kwiz/  ", content);
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao criar kwiz: {ex.Message}");
            return false;
        }
    }
    
    public async Task<ApiResponse<IEnumerable<KwizDto>>?> GetAll()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/kwiz/");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<IEnumerable<KwizDto>>>();
            return apiResponse;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return null;
    }

    public async Task<ApiResponse<KwizDto>?> GetById(Guid id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/kwiz/{id}");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<KwizDto>>();
            return apiResponse;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return null;
    }
}