using FastEndpoints;
using Quiz.API.Repositories;
using Quiz.Domain.Common.DTOs;
using Quiz.Infrastructure.Common;
using StatusCodes = Quiz.Infrastructure.Common.StatusCodes;

namespace Quiz.API.Endpoints.Accounts.EditUser;

public class EditUserEndpoint(AccountService account) : Endpoint<UserDto, ApiResponse>
{
    public override void Configure()
    {
        Put("/api/user/");
        Description(x => x.WithTags("Account"));
        AllowAnonymous();
    }

    public override async Task<ApiResponse> ExecuteAsync(UserDto req, CancellationToken ct)
    {
        var result = await account.EditUser(req);
        if (result)
            return new ApiResponse(true, "Conta Editada com sucesso!", StatusCodes.Ok);
        return new ApiResponse(true, "Aconteceu um erro ao editar a conta!!", StatusCodes.InternarServerError);
    }
}