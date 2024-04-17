using System.Net;
using System.Text.Json;
using UserManagement.Domain.Constants;
using UserManagement.Domain.GenericResponse;

namespace UserManagmenet.API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IWebHostEnvironment _env;
    public ExceptionHandlingMiddleware(RequestDelegate next, IWebHostEnvironment env)
    {
        _next = next;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var payload = ex.InnerException != null ? ex.InnerException.ToString() : string.Empty;
            var response = _env.IsDevelopment() || _env.IsProduction() ?
                GenericResponse<string>.Failure(payload, ex.Message, (int)HttpStatusCode.InternalServerError) :
                GenericResponse<string>.Failure(ApiResponseMessages.SOMETHING_WENT_WRONG, (int)HttpStatusCode.InternalServerError);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            string json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }
    }
}
