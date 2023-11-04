namespace AutoYa_Backend.AutoYa.Domain.Models;

public class Mantenimiento
{
    public int Id { get; set; } //primary key
    public string TipoProblema { get; set; }
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public string UrlImagen { get; set; }

    // Relaciones
    // Un mensaje de mantenimiento solo puede tener un propietario y un arrendatario
    public int ArrendatarioId { get; set; } // FK
    public Arrendatario Arrendatario { get; set; }

    public int PropietarioId { get; set; } // FK
    public Propietario Propietario { get; set; }

}