using JalaTodoApi.Exceptions;
using System.Net;

namespace JalaTodoApi.Middlewares;

public class ExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)((exception as ApiException)?.StatusCode ?? HttpStatusCode.InternalServerError);

        var jsonResponse = System.Text.Json.JsonSerializer.Serialize(new
        {
            statusCode = context.Response.StatusCode,
            message = exception.Message
        });

        return context.Response.WriteAsync(jsonResponse);
    }
}
