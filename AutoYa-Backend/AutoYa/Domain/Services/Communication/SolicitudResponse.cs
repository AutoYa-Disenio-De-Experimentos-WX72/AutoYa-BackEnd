using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Shared.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services.Communication;

/// <summary>
/// Clase que representa la respuesta de una operación relacionada con la entidad Solicitud.
/// </summary>
public class SolicitudResponse : BaseResponse<Solicitud>
{
    /// <summary>
    /// Constructor para una respuesta que indica un error.
    /// </summary>
    /// <param name="message">Mensaje de error.</param>
    public SolicitudResponse(string message) : base(message)
    {
    }

    /// <summary>
    /// Constructor para una respuesta exitosa.
    /// </summary>
    /// <param name="resource">Recursos relacionados con la respuesta.</param>
    public SolicitudResponse(Solicitud resource) : base(resource)
    {
    }
}