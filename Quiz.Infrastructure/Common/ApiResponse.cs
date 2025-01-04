namespace Quiz.Infrastructure.Common;

public record ApiResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public StatusCodes Status { get; set; }

    public ApiResponse(bool success, string message, StatusCodes status)
    {
        Success = success;
        Message = message;
        Status = status;
    }
}

public record ApiResponse<T> : ApiResponse
{
    public T? Data { get; set; }

    public ApiResponse(bool success, string message, StatusCodes status, T? data) : base(success, message, status)
    {
        Data = data;
    }
}