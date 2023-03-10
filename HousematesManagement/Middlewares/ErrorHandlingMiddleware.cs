using HousemateManagement.Exceptions;
using System.Text.Json;
using System.Net;

namespace HousemateManagement.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var response = context.Response;
            try
            {
                await _next.Invoke(context);
            }
            catch (NotFoundException error)
            {
                _logger.LogError($"Moj logger: {context.Request},{context.Response},{error}");
                await HandleExceptionAsync(context, error);
            }

            catch (Exception error)
            {
                await HandleExceptionAsync(context, error);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new { message = exception.Message });
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
