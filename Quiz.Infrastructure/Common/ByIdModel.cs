
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace Quiz.Infrastructure.Common;

public record ByIdModel()
{
    [QueryParam]
    public Guid Id { get; set; }
}