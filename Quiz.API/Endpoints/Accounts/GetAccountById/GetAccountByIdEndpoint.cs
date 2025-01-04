using FastEndpoints;
using Quiz.API.Repositories;
using Quiz.Domain.Common.DTOs;
using Quiz.Infrastructure.Common;
using StatusCodes = Quiz.Infrastructure.Common.StatusCodes;

namespace Quiz.API.Endpoints.Accounts.GetAccountById;

public class GetAccountByIdEndpoint(AccountService account) : EndpointWithoutRequest<ApiResponse<AccountDto>>
{
    public override void Configure()
    {
        Get("/api/account/{id:guid}");
        Description(x => x.WithTags("Account"));
        AllowAnonymous();
    }

    public override async Task<ApiResponse<AccountDto>> ExecuteAsync(CancellationToken ct)
    {
        var rota = Route<Guid>("id");
        var result = await account.GetAccountById(rota);
        if (result is null)
        {
            return new ApiResponse<AccountDto>(false, "Conta nao encontrada!!", StatusCodes.NotFound, null);
        }

        return new ApiResponse<AccountDto>(false, "Conta Encontrada", StatusCodes.Ok, result);
    }
}