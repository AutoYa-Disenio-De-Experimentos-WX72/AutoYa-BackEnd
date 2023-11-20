using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoYa_Backend.Security.Authorization.Handlers.Interfaces;
using AutoYa_Backend.Security.Authorization.Settings;
using AutoYa_Backend.Security.Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AutoYa_Backend.Security.Authorization.Handlers.Implementations;

/// <summary>
/// Clase que maneja la generación y validación de tokens JWT.
/// </summary>
public class JwtHandler : IJwtHandler
{
    private readonly AppSettings _appSettings;
    /// <summary>
    /// Constructor que inicializa las configuraciones de la aplicación.
    /// </summary>
    /// <param name="appSettings">Configuraciones de la aplicación.</param>
    public JwtHandler(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }
    /// <summary>
    /// Genera un token para un usuario.
    /// </summary>
    /// <param name="user">El usuario para el que se generará el token.</param>
    /// <returns>El token generado.</returns>
    public string GenerateToken(User user)
    {
        // Genera un token válido por un período de 7 días
        var tokenHandler = new JwtSecurityTokenHandler();
        Console.WriteLine($"token handler: {tokenHandler.TokenType}");
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        Console.WriteLine($"Secret Key: {key}");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("id", user.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        Console.WriteLine($"token: {token.Id}, {token.Issuer}, {token.SecurityKey?.ToString()}");
        return tokenHandler.WriteToken(token);
    }

    /// <summary>
    /// Valida un token.
    /// </summary>
    /// <param name="token">El token a validar.</param>
    /// <returns>El ID del usuario si el token es válido, null en caso contrario.</returns>
    public int? ValidateToken(string token)
    {
        if (token == null)
            return null;
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        
        // Ejecuta la validación del token
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // Expiration with no delay
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);
            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(
                claim => claim.Type == "id").Value);
            return userId;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}