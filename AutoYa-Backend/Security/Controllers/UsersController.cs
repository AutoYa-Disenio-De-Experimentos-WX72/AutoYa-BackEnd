using AutoMapper;
using AutoYa_Backend.Security.Authorization.Attributes;
using AutoYa_Backend.Security.Domain.Models;
using AutoYa_Backend.Security.Domain.Services;
using AutoYa_Backend.Security.Domain.Services.Communication;
using AutoYa_Backend.Security.Resources;
using Microsoft.AspNetCore.Mvc;

namespace AutoYa_Backend.Security.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]

/// <summary>
/// Controlador de usuarios.
/// </summary>
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    
    /// <summary>
    /// Constructor que inicializa el servicio de usuario y el mapeador.
    /// </summary>
    /// <param name="userService">El servicio de usuario.</param>
    /// <param name="mapper">El mapeador.</param>
    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Autentica un usuario.
    /// </summary>
    /// <param name="request">La solicitud de autenticación.</param>
    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest request)
    {
        var response = await _userService.Authenticate(request);
        return Ok(response);
    }

    /// <summary>
    /// Registra un nuevo usuario.
    /// </summary>
    /// <param name="request">La solicitud de registro.</param>
    [AllowAnonymous]
    [HttpPost("sign-up")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await _userService.RegisterAsync(request);
        return Ok(new { message = "Registration successful" });
    }
    
    /// <summary>
    /// Obtiene todos los usuarios.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
        return Ok(resources);
    }

    /// <summary>
    /// Obtiene un usuario por su ID.
    /// </summary>
    /// <param name="id">El ID del usuario.</param>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        var resource = _mapper.Map<User, UserResource>(user);
        return Ok(resource);
    }
    
    /// <summary>
    /// Actualiza un usuario.
    /// </summary>
    /// <param name="id">El ID del usuario.</param>
    /// <param name="request">La solicitud de actualización.</param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateRequest request)
    {
        await _userService.UpdateAsync(id, request);
        return Ok(new { message = "User updated successfully" });
    }

    /// <summary>
    /// Elimina un usuario.
    /// </summary>
    /// <param name="id">El ID del usuario.</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.DeleteAsync(id);
        return Ok(new { message = "User deleted successfully" });
    }
}