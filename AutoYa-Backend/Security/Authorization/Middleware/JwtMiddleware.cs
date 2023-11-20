using AutoYa_Backend.Security.Authorization.Handlers.Interfaces;
using AutoYa_Backend.Security.Authorization.Settings;
using AutoYa_Backend.Security.Domain.Services;
using Microsoft.Extensions.Options;

namespace AutoYa_Backend.Security.Authorization.Middleware;

/// <summary>
/// Clase que maneja el middleware de JWT.
/// </summary>
public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    
    /// <summary>
    /// Constructor que inicializa el siguiente delegado de solicitud y las configuraciones de la aplicación.
    /// </summary>
    /// <param name="next">El siguiente delegado de solicitud.</param>
    /// <param name="appSettings">Configuraciones de la aplicación.</param>
    public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
    }
    
    /// <summary>
    /// Método que se invoca para procesar la solicitud HTTP.
    /// </summary>
    /// <param name="context">El contexto HTTP.</param>
    /// <param name="userService">El servicio de usuario.</param>
    /// <param name="handler">El manejador de JWT.</param>
    public async Task Invoke(HttpContext context, IUserService userService, IJwtHandler handler)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var userId = handler.ValidateToken(token);
        if (userId != null)
        {
            // Adjunta el usuario al contexto en una validación jwt exitosa
            context.Items["User"] = await userService.GetByIdAsync(userId.Value);
        }
        await _next(context);
    }
}