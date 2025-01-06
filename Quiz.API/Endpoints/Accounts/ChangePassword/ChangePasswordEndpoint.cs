using FastEndpoints;
using Quiz.API.Repositories;
using Quiz.Domain.Common.DTOs;
using Quiz.Infrastructure.Common;
using StatusCodes = Quiz.Infrastructure.Common.StatusCodes;

namespace Quiz.API.Endpoints.Accounts.ChangePassword;

public class ChangePasswordEndpoint(AccountService account) : Endpoint<AccountDto, ApiResponse>
{
    public override void Configure()
    {
        Put("/api/account/password");
        Description(x => x.WithTags("Account"));
        AllowAnonymous();
    }

    public override async Task<ApiResponse> ExecuteAsync(AccountDto req, CancellationToken ct)
    {
        var result = await account.ChangePassword(req);
        if (result)
            return new ApiResponse(true, "Palavrapasse alterada com sucesso!", StatusCodes.Ok);
        return new ApiResponse(true, "Aconteceu um erro ao alterar palavrapasse!!", StatusCodes.InternarServerError);
    }
}