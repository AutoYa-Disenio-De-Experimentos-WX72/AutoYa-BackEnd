namespace AutoYa_Backend.AutoYa.Resources;

public class ArrendatarioResource
{
    public int Id { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public int Telefono { get; set; }
    public string Correo { get; set; }
    public string? AntecedentesPenalesPdf { get; set; }
    public string Contrasenia { get; set; }
}

