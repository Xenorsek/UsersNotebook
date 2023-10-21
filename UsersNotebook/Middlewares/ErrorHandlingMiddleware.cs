using System.ComponentModel.DataAnnotations;
using UserNotebook.Core.Exceptions;

namespace UsersNotebook.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException notFoundException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch (ValidationException notFoundException)
            {
                context.Response.StatusCode = 403;
                context.Response.Headers.Add("X-Status-Reason", "Validation failed");
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch (ArgumentNullException argumentNullException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(argumentNullException.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.StackTrace);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync($"Something went wrong: {ex.Message}");
            }
        }
    }
}
