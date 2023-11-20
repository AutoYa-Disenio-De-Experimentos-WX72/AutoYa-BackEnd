namespace AutoYa_Backend.AutoYa.Domain.Models;

/// <summary>
    /// Representa a un propietario de vehículos en el sistema.
    /// </summary>
    public class Propietario
    {
        /// <summary>
        /// Obtiene o establece el identificador del propietario (clave primaria).
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece los nombres del propietario.
        /// </summary>
        public string Nombres { get; set; }

        /// <summary>
        /// Obtiene o establece los apellidos del propietario.
        /// </summary>
        public string Apellidos { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de nacimiento del propietario.
        /// </summary>
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// Obtiene o establece el número de teléfono del propietario.
        /// </summary>
        public int Telefono { get; set; }

        /// <summary>
        /// Obtiene o establece la dirección de correo electrónico del propietario.
        /// </summary>
        public string Correo { get; set; }

        /// <summary>
        /// Obtiene o establece la contraseña asociada al propietario.
        /// </summary>
        public string Contrasenia { get; set; }

        /// <summary>
        /// Obtiene la lista de vehículos asociados a este propietario.
        /// </summary>
        public IList<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();

        /// <summary>
        /// Obtiene la lista de alquileres realizados por este propietario.
        /// </summary>
        public IList<Alquiler> Alquileres { get; set; } = new List<Alquiler>();

        /// <summary>
        /// Obtiene la lista de mantenimientos registrados por este propietario.
        /// </summary>
        public IList<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();

        /// <summary>
        /// Obtiene la lista de notificaciones asociadas a este propietario.
        /// </summary>
        public IList<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();
    }