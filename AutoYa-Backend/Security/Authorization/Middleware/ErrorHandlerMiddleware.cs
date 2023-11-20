using System.Net;
using System.Text.Json;
using AutoYa_Backend.Security.Exceptions;

namespace AutoYa_Backend.Security.Authorization.Middleware;

/// <summary>
/// Clase que maneja los errores en el middleware.
/// </summary>
public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    /// <summary>
    /// Constructor que inicializa el siguiente delegado de solicitud.
    /// </summary>
    /// <param name="next">El siguiente delegado de solicitud.</param>
    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    /// <summary>
    /// Método que se invoca para procesar la solicitud HTTP.
    /// </summary>
    /// <param name="context">El contexto HTTP.</param>
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            switch(error)
            {
                case AppException e:
                    // Error de aplicación personalizado
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException e:
                    // Error de no encontrado
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    // Error no manejado
                    response.StatusCode = 
                        (int)HttpStatusCode.InternalServerError;
                    break;
            }
            var result = JsonSerializer.Serialize(new { message = error?.Message });
            await response.WriteAsync(result);
        }
    }
}