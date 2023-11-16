namespace AutoYa_Backend.AutoYa.Resources;

public class SaveArrendatarioResource
{
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public int Telefono { get; set; }
    public string Correo { get; set; }
    public string? AntecedentesPenalesPdf { get; set; } //cambiar el string a IFormFile
    public string Contrasenia { get; set; }
}