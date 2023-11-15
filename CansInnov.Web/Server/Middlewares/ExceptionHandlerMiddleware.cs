using CansInnov.Application.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace CansInnov.Server.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                context.Response.ContentType = "application/json";
                string? response = string.Empty;
                switch (e)
                {
                    case ValidationException validationException:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        response = validationException.ValidationResult.ErrorMessage;
                        _logger.LogError($"Erreur de validation de la commande {response}");
                        break;
                    case NotFoundException:
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        response = JsonSerializer.Serialize(e.Message);
                        break;
                    default:
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        _logger.LogError($"Erreur inconnue : {e.Message}", e);
                        break;
                }

                await context.Response.WriteAsync(response);
            }
        }
    }
}