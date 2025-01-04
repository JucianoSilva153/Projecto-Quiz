using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Quiz.API.Repositories;
using Quiz.Domain.Common.DTOs;
using Quiz.Domain.Entities.Accounts;
using Quiz.Infrastructure.Common;
using StatusCodes = Quiz.Infrastructure.Common.StatusCodes;

namespace Quiz.API.Endpoints.Accounts.CreateAccount;

public class CreateAccountEndpoint(AccountService account)
    : Endpoint<AccountDto, ApiResponse>
{
    [AllowAnonymous]
    public override void Configure()
    {
        Post("/api/account");
        Description(x => x.WithTags("Account"));
        AllowAnonymous();
    }

    public override async Task<ApiResponse> ExecuteAsync(AccountDto req, CancellationToken ct)
    {
        var result = await account.CreateAccountAsync(req);
        if (result)
        {
            HttpContext.Response.StatusCode = 201;
            return new ApiResponse(true, "Conta Criado Com Sucesso!!", StatusCodes.Created);
        }

        HttpContext.Response.StatusCode = 500;
        return new ApiResponse(false, "Erro ao cria conta!!", StatusCodes.InternarServerError);
    }
}