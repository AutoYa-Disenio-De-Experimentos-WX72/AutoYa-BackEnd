namespace AutoYa_Backend.AutoYa.Domain.Models;

public class Solicitud
{
    public int Id { get; set; }
    public string Body { get; set; }

    // Relaciones
    // Una solicitud solo puede pertenecer a un alquiler
    public int AlquilerId { get; set; } // Foreign key
    public Alquiler Alquiler { get; set; }

}