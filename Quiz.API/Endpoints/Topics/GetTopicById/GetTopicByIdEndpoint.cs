using FastEndpoints;
using Quiz.API.Repositories;
using Quiz.Domain.Common.DTOs;
using Quiz.Infrastructure.Common;
using StatusCodes = Quiz.Infrastructure.Common.StatusCodes;

namespace Quiz.API.Endpoints.Topics.GetTopicById;

public class GetTopicByIdEndpoint(TopicService topic) : EndpointWithoutRequest<ApiResponse<TopicDto>>
{
    public override void Configure()
    {
        Get("api/topic/{id:guid}");
        Description(x => x.WithTags("Topic"));
        AllowAnonymous();
    }

    public override async Task<ApiResponse<TopicDto>> ExecuteAsync(CancellationToken ct)
    {
        var id = Route<Guid>("id");
        var result = await topic.GetById(id);
        if (result is null)
        {
            return new ApiResponse<TopicDto>(false, "Topico nao encontrado!!", StatusCodes.NotFound, null);
        }

        return new ApiResponse<TopicDto>(false, "Topico Encontrado", StatusCodes.Ok, result);
    }
}