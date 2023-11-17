using AutoYa_Backend.Security.Domain.Models;

namespace AutoYa_Backend.Security.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    public string GenerateToken(User user);
    public int? ValidateToken(string token);
}