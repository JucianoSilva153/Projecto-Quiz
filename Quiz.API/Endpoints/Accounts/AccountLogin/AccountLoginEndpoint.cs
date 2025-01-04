using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Quiz.API.Repositories;
using Quiz.Domain.Common.DTOs;
using Quiz.Infrastructure.Common;
using StatusCodes = Quiz.Infrastructure.Common.StatusCodes;

namespace Quiz.API.Endpoints.Accounts.AccountLogin;

public class AccountLoginEndpoint(AccountService account)
    : Endpoint<LoginDto, ApiResponse<CurrentUser?>>
{
    public override void Configure()
    {
        Post("api/account/login");
        Description(x => x.WithTags("Account"));
        AllowAnonymous();
    }

    public override async Task<ApiResponse<CurrentUser?>> ExecuteAsync(LoginDto req, CancellationToken ct)
    {
        var result = await account.LoginAsync(req);

        if (result is not null)
        {
            HttpContext.Response.StatusCode = 200;
            return new ApiResponse<CurrentUser>(true, "Login Efetuado Com Sucesso!!",
                StatusCodes.Ok, result)!;
        }
        else
        {
            HttpContext.Response.StatusCode = 404;
            return new ApiResponse<CurrentUser?>(false, "Nao foi possivel encontrar a conta solicitada!!",
                StatusCodes.NotFound, null);
        }
    }
}