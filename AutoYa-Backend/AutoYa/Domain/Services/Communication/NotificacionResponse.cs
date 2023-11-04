using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Shared.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services.Communication;

public class NotificacionResponse : BaseResponse<Notificacion>
{
    public NotificacionResponse(string message) : base(message)
    {
    }

    public NotificacionResponse(Notificacion resource) : base(resource)
    {
    }
}