namespace AutoYa_Backend.AutoYa.Domain.Models;

public class Arrendatario
{
    public int Id { get; set; } // Primary key
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public int Telefono { get; set; }
    public string Correo { get; set; }
    public byte[] AntecedentesPenalesPdf { get; set; }

    // Relaciones
    // Un arrendatario puede alquilar uno o más vehículos
    public IList<Vehiculo> VehiculosAlquilados { get; set; } = new List<Vehiculo>(); // un arrendatario puede tener un o o más vehículos

    public IList<Alquiler> Alquileres { get; set; } = new List<Alquiler>(); //un arrendatario puede tener muchos alquileres

    public IList<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>(); //un arrendatario puede tener muchos mantenimientos

    public IList<Notificacion> Notificaciones { get; set; } = new List<Notificacion>(); //un arrendatario puede tener muchas notificaciones

    /* cortar y pegar en el controller debido
     * [HttpPost]
public ActionResult AgregarArrendatario(Arrendatario arrendatario, HttpPostedFileBase file)
{
    if (file != null && file.ContentLength > 0)
    {
        using (var reader = new BinaryReader(file.InputStream))
        {
            arrendatario.AntecedentesPenalesPdf = reader.ReadBytes(file.ContentLength);
        }
    }

    // Aquí puedes guardar el objeto Arrendatario en tu base de datos o realizar otras operaciones.

    // Redirige a la página de confirmación o donde sea necesario.
    return RedirectToAction("Confirmacion");
}

     */
}