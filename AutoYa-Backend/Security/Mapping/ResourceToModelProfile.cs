using AutoMapper;
using AutoYa_Backend.Security.Domain.Models;
using AutoYa_Backend.Security.Domain.Services.Communication;
using Org.BouncyCastle.Asn1.X509;

namespace AutoYa_Backend.Security.Mapping;

/// <summary>
/// Clase que representa el perfil de mapeo de recurso a modelo.
/// </summary>
public class ResourceToModelProfile : Profile
{
    /// <summary>
    /// Constructor que inicializa los mapeos de recurso a modelo.
    /// </summary>
    public ResourceToModelProfile()
    {
        // Mapeo de RegisterRequest a User
        CreateMap<RegisterRequest, User>();
        // Mapeo de UpdateRequest a User
        CreateMap<UpdateRequest, User>()
            .ForAllMembers(options => options.Condition(
                (source, target, property) =>
                {
                    // Si la propiedad es nula, no se mapea
                    if (property == null) return false;
                    // Si la propiedad es una cadena vacía, no se mapea
                    if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                    return true;
                }
                ));
    }
}