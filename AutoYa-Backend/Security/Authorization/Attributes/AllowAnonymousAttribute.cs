namespace AutoYa_Backend.Security.Authorization.Attributes;

[AttributeUsage(AttributeTargets.Method)]

/// <summary>
/// Clase que representa un atributo que permite el acceso anónimo.
/// </summary>
public class AllowAnonymousAttribute : Attribute
{
    
}