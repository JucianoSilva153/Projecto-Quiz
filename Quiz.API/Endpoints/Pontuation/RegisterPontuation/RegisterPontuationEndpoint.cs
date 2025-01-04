using FastEndpoints;
using Quiz.API.Repositories;
using Quiz.Domain.Common.DTOs;
using Quiz.Infrastructure.Common;
using StatusCodes = Quiz.Infrastructure.Common.StatusCodes;

namespace Quiz.API.Endpoints.Pontuation.RegisterPontuation;

public class RegisterPontuationEndpoint(PointsService points) : Endpoint<PointDto, ApiResponse>
{
    public override void Configure()
    {
        Post("api/point");
        Description(x => x.WithTags("Point"));
        AllowAnonymous();
    }

    public override async Task<ApiResponse> ExecuteAsync(PointDto req, CancellationToken ct)
    {
        var result = await points.RegisterPoints(req);
        if (result)
        {
            HttpContext.Response.StatusCode = 201;
            return new ApiResponse(true, "Pontuacao registada Com Sucesso!!", StatusCodes.Created);
        }
        
        HttpContext.Response.StatusCode = 500;
        return new ApiResponse(false, "Erro ao registar pontuacao", StatusCodes.InternarServerError);
    }
}