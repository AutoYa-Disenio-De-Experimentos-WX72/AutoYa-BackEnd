using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Shared.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services.Communication;

public class SolicitudResponse : BaseResponse<Solicitud>
{
    public SolicitudResponse(string message) : base(message)
    {
    }

    public SolicitudResponse(Solicitud resource) : base(resource)
    {
    }
}