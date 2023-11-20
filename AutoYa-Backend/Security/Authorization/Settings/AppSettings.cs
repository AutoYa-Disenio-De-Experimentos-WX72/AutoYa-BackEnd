namespace AutoYa_Backend.Security.Authorization.Settings;

/// <summary>
/// Clase que contiene las configuraciones de la aplicación.
/// </summary>
public class AppSettings
{
    /// <summary>
    /// Obtiene o establece el secreto de la aplicación.
    /// </summary>
    public string Secret { get; set; }
}