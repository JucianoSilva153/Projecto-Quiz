using System.Collections;
using FastEndpoints;
using Quiz.API.Repositories;
using Quiz.Domain.Common.DTOs;
using Quiz.Infrastructure.Common;
using StatusCodes = Quiz.Infrastructure.Common.StatusCodes;

namespace Quiz.API.Endpoints.Kwizzes.GetKwizzes;

public class GetKwizzesEndpoint(KwizzService kwiz) : EndpointWithoutRequest<ApiResponse<IEnumerable<KwizDto>>>
{
    public override void Configure()
    {
        Get("api/kwiz");
        Description(x => x.WithTags("Kwiz"));
        AllowAnonymous();
    }

    public override async Task<ApiResponse<IEnumerable<KwizDto>>> ExecuteAsync(CancellationToken ct)
    {
        var result = await kwiz.GetAll();
        return new ApiResponse<IEnumerable<KwizDto>>(true, "Kwizzes Listados", StatusCodes.Ok, result);
    }
}