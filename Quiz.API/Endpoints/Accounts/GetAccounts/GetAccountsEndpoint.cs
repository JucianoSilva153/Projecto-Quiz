using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using Quiz.API.Repositories;
using Quiz.Domain.Common.DTOs;
using Quiz.Infrastructure.Common;
using StatusCodes = Quiz.Infrastructure.Common.StatusCodes;

namespace Quiz.API.Endpoints.Accounts.GetAccounts;

public class GetAccountsEndpoint(AccountService account) : EndpointWithoutRequest<ApiResponse<IEnumerable<AccountDto>>>
{
    public override void Configure()
    {
        Get("/api/account");
        Description(x => x.WithTags("Account"));
        AllowAnonymous();
    }

    public override async Task<ApiResponse<IEnumerable<AccountDto>>> ExecuteAsync(CancellationToken ct)
    {
        var result = await account.GetAccounts();
        return new ApiResponse<IEnumerable<AccountDto>>(true, "Lista de Contas", StatusCodes.Ok, result);
    }
}

