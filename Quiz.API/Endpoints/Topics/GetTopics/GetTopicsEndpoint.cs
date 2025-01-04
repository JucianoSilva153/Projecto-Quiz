using FastEndpoints;
using Quiz.API.Repositories;
using Quiz.Domain.Common.DTOs;
using Quiz.Infrastructure.Common;
using StatusCodes = Quiz.Infrastructure.Common.StatusCodes;

namespace Quiz.API.Endpoints.Topics.GetTopics;

public class GetTopicsEndpoint(TopicService topic) : EndpointWithoutRequest<ApiResponse<IEnumerable<TopicDto>>>
{
    public override void Configure()
    {
        Get("api/topic");
        Description(x => x.WithTags("Topic"));
        AllowAnonymous();
    }

    public override async Task<ApiResponse<IEnumerable<TopicDto>>> ExecuteAsync(CancellationToken ct)
    {
        var result = await topic.GetAll();
        return new ApiResponse<IEnumerable<TopicDto>>(true, "Lista de Topicos", StatusCodes.Ok, result);
    }
}