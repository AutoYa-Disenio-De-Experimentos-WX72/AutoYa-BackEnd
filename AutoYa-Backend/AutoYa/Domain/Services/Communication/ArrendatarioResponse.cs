using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Shared.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services.Communication;

/// <summary>
/// Clase que representa la respuesta de una operación relacionada con la entidad Arrendatario.
/// </summary>
public class ArrendatarioResponse : BaseResponse<Arrendatario>
{
    /// <summary>
    /// Constructor para una respuesta que indica un error.
    /// </summary>
    /// <param name="message">Mensaje de error.</param>
    public ArrendatarioResponse(string message) : base(message)
    {
    }

    /// <summary>
    /// Constructor para una respuesta exitosa.
    /// </summary>
    /// <param name="resource">Recursos relacionados con la respuesta.</param>
    public ArrendatarioResponse(Arrendatario resource) : base(resource)
    {
    }
}