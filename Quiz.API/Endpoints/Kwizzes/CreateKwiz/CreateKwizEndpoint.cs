using FastEndpoints;
using Quiz.API.Repositories;
using Quiz.Domain.Common.DTOs;
using Quiz.Infrastructure.Common;
using StatusCodes = Quiz.Infrastructure.Common.StatusCodes;

namespace Quiz.API.Endpoints.Kwizzes.CreateKwiz;

public class CreateKwizEndpoint(KwizzService kwiz) : Endpoint<KwizDto, ApiResponse>
{
    public override void Configure()
    {
        Post("api/kwiz");
        Description(x => x.WithTags("Kwiz"));
        AllowAnonymous();
    }

    public override async Task<ApiResponse> ExecuteAsync(KwizDto req, CancellationToken ct)
    {
        var result = await kwiz.CreateAsync(req);
        if (result)
        {
            HttpContext.Response.StatusCode = 201;
            return new ApiResponse(true, "Kwiz Criado Com Sucesso!!", StatusCodes.Created);
        }
        
        HttpContext.Response.StatusCode = 500;
        return new ApiResponse(false, "Erro ao criar kwiz!!", StatusCodes.InternarServerError);
    }
}