namespace AutoYa_Backend.AutoYa.Domain.Models;

public class Notificacion
{
    public int Id { get; set; } //primary key
    public string Body { get; set; } // Contenido del mensaje (ya sea solicitud o mensaje de mantenimiento)

    // Relaciones
    // Una notificación solo puede pertenecer a un propietario y a un arrendatario
    public int PropietarioId { get; set; } // Foreign key a quien debe llegar
    public Propietario Propietario { get; set; }

    public int ArrendatarioId { get; set; } // Foreign key de quien viene
    public Arrendatario Arrendatario { get; set; }

}