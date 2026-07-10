using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Ardent.AuctionHouse.Middleware;

public sealed class GlobalExceptionHandler(
    ILogger<GlobalExceptionHandler> logger,
    IHostEnvironment environment)
    : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(
            exception,
            "Unhandled exception occurred while processing {Method} {Path}",
            httpContext.Request.Method,
            httpContext.Request.Path);

        var (statusCode, title) = exception switch
        {
            ArgumentException => (
                StatusCodes.Status400BadRequest,
                "Invalid request."),

            UnauthorizedAccessException => (
                StatusCodes.Status403Forbidden,
                "Forbidden."),

            _ => (
                StatusCodes.Status500InternalServerError,
                "An unexpected error occurred.")
        };

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Type = $"https://httpstatuses.com/{statusCode}",
            Instance = httpContext.Request.Path
        };

        problemDetails.Extensions["traceId"] = httpContext.TraceIdentifier;

        if (environment.IsDevelopment())
        {
            problemDetails.Detail = exception.Message;
        }

        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsJsonAsync(
            problemDetails,
            cancellationToken);

        return true;
    }
}