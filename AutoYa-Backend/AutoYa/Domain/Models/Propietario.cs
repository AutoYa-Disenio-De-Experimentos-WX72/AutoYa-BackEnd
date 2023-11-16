namespace AutoYa_Backend.AutoYa.Domain.Models;

public class Propietario
{
    public int Id { get; set; } // Primary key
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public int Telefono { get; set; }
    public string Correo { get; set; }
    public string Contrasenia { get; set; }

    // Relaciones
    // Un propietario puede tener uno o más vehículos
    public IList<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>(); //un arrendatario puede tener uno o más vehículos alquilados

    public IList<Alquiler> Alquileres { get; set; } = new List<Alquiler>(); //un propietario puede tener muchos alquileres

    public IList<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>(); //un propietario puede tener muchos mantenimientos

    public IList<Notificacion> Notificaciones { get; set; } = new List<Notificacion>(); //un propietario puede tener muchas notificaciones
}