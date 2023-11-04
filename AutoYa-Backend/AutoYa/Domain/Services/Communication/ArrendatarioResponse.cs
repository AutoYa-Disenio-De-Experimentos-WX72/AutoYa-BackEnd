using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Shared.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services.Communication;

public class ArrendatarioResponse : BaseResponse<Arrendatario>
{
    public ArrendatarioResponse(string message) : base(message)
    {
    }

    public ArrendatarioResponse(Arrendatario resource) : base(resource)
    {
    }
}