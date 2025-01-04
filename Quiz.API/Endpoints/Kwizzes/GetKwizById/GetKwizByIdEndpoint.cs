using FastEndpoints;
using Quiz.API.Repositories;
using Quiz.Domain.Common.DTOs;
using Quiz.Infrastructure.Common;
using StatusCodes = Quiz.Infrastructure.Common.StatusCodes;

namespace Quiz.API.Endpoints.Kwizzes.GetKwizById;

public class GetKwizByIdEndpoint(KwizzService kwiz) : EndpointWithoutRequest<ApiResponse<KwizDto>>
{
    public override void Configure()
    {
        Get("api/kwiz/{id:guid}");
        Description(x => x.WithTags("Kwiz"));
        AllowAnonymous();
    }

    public override async Task<ApiResponse<KwizDto>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<Guid>("id");
        var result = await kwiz.GetById(id);
        if (result is null)
        {
            return new ApiResponse<KwizDto>(false, "Kwiz nao encontrado!!", StatusCodes.NotFound, null);
        }

        return new ApiResponse<KwizDto>(true, "kwiz Encontrado", StatusCodes.Ok, result);
    }
}