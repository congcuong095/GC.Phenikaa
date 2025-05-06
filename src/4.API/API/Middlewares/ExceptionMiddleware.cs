using System.Text.Json;
using Domain.Exceptions;
using ExceptionLocalization;
using Microsoft.Extensions.Localization;
using Serilog;

namespace API.Middleware;

public sealed class ExceptionMiddleware : IMiddleware
{
    private readonly IStringLocalizer<ExceptionResource> _localizer;

    public ExceptionMiddleware(IStringLocalizer<ExceptionResource> localizer)
    {
        _localizer = localizer;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            Log.Error(e, e.Message);
            await HandleExceptionAsync(context, e);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.ContentType = "application/json";

        httpContext.Response.StatusCode = exception switch
        {
            CustomBadRequestException => StatusCodes.Status400BadRequest,
            CustomNotFoundException => StatusCodes.Status404NotFound,
            CustomUnauthorizedException => StatusCodes.Status401Unauthorized,
            CustomForbiddenException => StatusCodes.Status403Forbidden,
            _ => StatusCodes.Status500InternalServerError,
        };

        var message = _localizer[exception.Message];

        var response = new
        {
            Message = message != null ? message.Value : (exception.Message ?? "Internal Error"),
        };

        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
