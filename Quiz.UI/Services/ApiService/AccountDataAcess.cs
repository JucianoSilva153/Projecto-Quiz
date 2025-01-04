using System.Net;
using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;
using Quiz.Domain.Common.DTOs;
using Quiz.Infrastructure.Common;

namespace Quiz.UI.Services.ApiService;

public class AccountDataAcess
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<AccountDataAcess> _logger;

    public AccountDataAcess(HttpClient httpClient, ILogger<AccountDataAcess> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<bool> CreateAsync(AccountDto account)
    {
        try
        {
            var json = JsonConvert.SerializeObject(account);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/account/  ", content);
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao criar usuário: {ex.Message}");
            return false;
        }
    }

    public async Task<ApiResponse<IEnumerable<AccountDto>>?> GetAll()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/account/");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<IEnumerable<AccountDto>>>();
            return apiResponse;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return null;
    }

    public async Task<ApiResponse<CurrentUser>?> LoginAsync(LoginDto loginAcess)
    {
        try
        {
            var json = JsonConvert.SerializeObject(loginAcess);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/account/login", content);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<ApiResponse<CurrentUser>>();
            if (response.StatusCode == HttpStatusCode.NotFound)
                return new ApiResponse<CurrentUser>(false, "Conta nao encontrada", StatusCodes.NotFound, null);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return null;
    }

    public async Task<CurrentUser?> RefreshLocalData(LoginDto acess)
    {
        var result = await LoginAsync(acess);
        if (result is not null && result.Success)
        {
            return result.Data;
        }

        return null;
    }
}