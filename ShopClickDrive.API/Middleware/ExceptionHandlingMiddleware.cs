using System.Net;
using System.Text.Json;
using ShopClickDrive.Core.Exceptions;

namespace ShopClickDrive.API.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        // Define default error details
        int statusCode;
        string errorMessage;

        // Customize based on exception type
        switch (exception)
        {
            case DealerNotFoundException notFoundException:
                statusCode = (int)HttpStatusCode.NotFound;
                errorMessage = notFoundException.Message;
                break;
            case ArgumentException argumentException:
                statusCode = (int)HttpStatusCode.BadRequest;
                errorMessage = argumentException.Message;
                break;
            default:
                statusCode = (int)HttpStatusCode.InternalServerError;
                errorMessage = exception.Message;
                break;
        }

        response.StatusCode = statusCode;

        var result = JsonSerializer.Serialize(new
        {
            error = errorMessage,
            statusCode
        });

        return response.WriteAsync(result);
    }
}