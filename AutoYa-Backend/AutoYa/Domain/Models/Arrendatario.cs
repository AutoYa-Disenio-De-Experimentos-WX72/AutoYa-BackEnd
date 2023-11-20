namespace AutoYa_Backend.AutoYa.Domain.Models;

/// <summary>
/// Representa a un arrendatario que puede alquilar vehículos y tiene diversas interacciones con el sistema.
/// </summary>
public class Arrendatario
{
    /// <summary>
    /// Obtiene o establece el identificador del arrendatario (clave primaria).
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Obtiene o establece el nombre(s) del arrendatario.
    /// </summary>
    public string Nombres { get; set; }

    /// <summary>
    /// Obtiene o establece los apellidos del arrendatario.
    /// </summary>
    public string Apellidos { get; set; }

    /// <summary>
    /// Obtiene o establece la fecha de nacimiento del arrendatario.
    /// </summary>
    public DateTime FechaNacimiento { get; set; }

    /// <summary>
    /// Obtiene o establece el número de teléfono del arrendatario.
    /// </summary>
    public int Telefono { get; set; }

    /// <summary>
    /// Obtiene o establece la dirección de correo electrónico del arrendatario.
    /// </summary>
    public string Correo { get; set; }

    /// <summary>
    /// Obtiene o establece la ruta del archivo PDF que contiene los antecedentes penales del arrendatario.
    /// </summary>
    public string? AntecedentesPenalesPdf { get; set; }

    /// <summary>
    /// Obtiene o establece la contraseña del arrendatario para acceder al sistema.
    /// </summary>
    public string Contrasenia { get; set; }

    /// <summary>
    /// Obtiene o establece la lista de vehículos que el arrendatario tiene actualmente alquilados.
    /// </summary>
    public IList<Vehiculo> VehiculosAlquilados { get; set; } = new List<Vehiculo>();

    /// <summary>
    /// Obtiene o establece la lista de alquileres realizados por el arrendatario.
    /// </summary>
    public IList<Alquiler> Alquileres { get; set; } = new List<Alquiler>();

    /// <summary>
    /// Obtiene o establece la lista de mantenimientos solicitados por el arrendatario.
    /// </summary>
    public IList<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();

    /// <summary>
    /// Obtiene o establece la lista de notificaciones recibidas por el arrendatario.
    /// </summary>
    public IList<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();
}