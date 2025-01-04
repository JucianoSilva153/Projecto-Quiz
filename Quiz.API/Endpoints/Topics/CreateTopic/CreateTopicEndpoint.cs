using FastEndpoints;
using Quiz.API.Repositories;
using Quiz.Domain.Common.DTOs;
using Quiz.Infrastructure.Common;
using StatusCodes = Quiz.Infrastructure.Common.StatusCodes;

namespace Quiz.API.Endpoints.Topics.CreateTopic;

public class CreateTopicEndpoint(TopicService topic) : Endpoint<TopicDto, ApiResponse>
{
    public override void Configure()
    {
        Post("api/topic");
        Description(x => x.WithTags("Topic"));
        AllowAnonymous();
    }

    public override async Task<ApiResponse> ExecuteAsync(TopicDto req, CancellationToken ct)
    {
        var result = await topic.CreateAccountAsync(req);
        if (result)
        {
            HttpContext.Response.StatusCode = 201;
            return new ApiResponse(true, "Topico Criado Com Sucesso!!", StatusCodes.Created);
        }
        
        HttpContext.Response.StatusCode = 500;
        return new ApiResponse(false, "Erro ao criar topico!!", StatusCodes.InternarServerError);
    }
}