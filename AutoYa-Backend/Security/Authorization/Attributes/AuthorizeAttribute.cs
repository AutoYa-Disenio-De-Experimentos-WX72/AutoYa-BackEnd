using AutoYa_Backend.Security.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AutoYa_Backend.Security.Authorization.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
/// <summary>
/// Clase que representa un atributo de autorización.
/// </summary>
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    /// <summary>
    /// Método que se ejecuta cuando se autoriza.
    /// </summary>
    /// <param name="context">El contexto de filtro de autorización.</param>
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Si la acción está decorada con el atributo [AllowAnonymous]
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        // Entonces se omite el proceso de autorización
        if (allowAnonymous)
            return;
        // Proceso de autorización
        var user = (User)context.HttpContext.Items["User"];
        if (user == null)
            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
    }
}