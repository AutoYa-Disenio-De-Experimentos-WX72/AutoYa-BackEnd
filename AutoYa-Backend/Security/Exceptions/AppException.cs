using System.Globalization;

namespace AutoYa_Backend.Security.Exceptions;

/// <summary>
/// Clase que representa una excepción de la aplicación.
/// </summary>
public class AppException : Exception
{
    /// <summary>
    /// Constructor por defecto.
    /// </summary>
    public AppException() : base() {}
    
    /// <summary>
    /// Constructor que inicializa la excepción con un mensaje específico.
    /// </summary>
    /// <param name="message">El mensaje de la excepción.</param>
    public AppException(string message) : base(message) { }
    
    /// <summary>
    /// Constructor que inicializa la excepción con un mensaje formateado.
    /// </summary>
    /// <param name="message">El formato del mensaje.</param>
    /// <param name="args">Los argumentos para formatear el mensaje.</param>
    public AppException(string message, params object[] args) 
        : base(String.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}