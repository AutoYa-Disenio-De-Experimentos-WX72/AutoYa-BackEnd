using AutoMapper;
using AutoYa_Backend.Security.Domain.Models;
using AutoYa_Backend.Security.Domain.Services.Communication;
using AutoYa_Backend.Security.Resources;

namespace AutoYa_Backend.Security.Mapping;

/// <summary>
/// Clase que representa el perfil de mapeo de modelo a recurso.
/// </summary>
public class ModelToResourceProfile : Profile
{
    /// <summary>
    /// Constructor que inicializa los mapeos de modelo a recurso.
    /// </summary>
    public ModelToResourceProfile()
    {
        // Mapeo de User a AuthenticateResponse
        CreateMap<User, AuthenticateResponse>();
        // Mapeo de User a UserResource
        CreateMap<User, UserResource>();
    }
}