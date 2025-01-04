using System.Collections;
using FastEndpoints;
using Quiz.API.Repositories;
using Quiz.Domain.Common.DTOs;
using Quiz.Infrastructure.Common;
using StatusCodes = Quiz.Infrastructure.Common.StatusCodes;

namespace Quiz.API.Endpoints.Pontuation.GetAllPontuations;

public class GetAllPontuationsEndpoint(PointsService points) : EndpointWithoutRequest<ApiResponse<IEnumerable<PointDto>>>
{
    public override void Configure()
    {
        Get("/api/point");
        Description(x => x.WithTags("Point"));
        AllowAnonymous();
    }

    public override async Task<ApiResponse<IEnumerable<PointDto>>> ExecuteAsync(CancellationToken ct)
    {
        var result = await points.GetAllPontuations();
        return new ApiResponse<IEnumerable<PointDto>>(true, "Pontos Listados", StatusCodes.Ok, result);
    }
}