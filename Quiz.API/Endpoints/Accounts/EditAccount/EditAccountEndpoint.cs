using FastEndpoints;
using Quiz.API.Repositories;
using Quiz.Domain.Common.DTOs;
using Quiz.Infrastructure.Common;
using StatusCodes = Quiz.Infrastructure.Common.StatusCodes;

namespace Quiz.API.Endpoints.Accounts.EditAccount;

public class EditAccountEndpoint(AccountService account) : Endpoint<AccountDto, ApiResponse>
{
    public override void Configure()
    {
        Put("/api/account/");
        Description(x => x.WithTags("Account"));
        AllowAnonymous();
    }

    public override async Task<ApiResponse> ExecuteAsync(AccountDto req, CancellationToken ct)
    {
        var result = await account.EditAccout(req);
        if (result)
            return new ApiResponse(true, "Conta Editada com sucesso!", StatusCodes.Ok);
        return new ApiResponse(true, "Aconteceu um erro ao editar a conta!!", StatusCodes.InternarServerError);
    }
}