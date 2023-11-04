using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Resources;
using Microsoft.AspNetCore.Mvc;

namespace AutoYa_Backend.AutoYa.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class PropietariosController : ControllerBase
{
    private readonly IPropietarioService _propietarioService;
    private readonly IMapper _mapper;

    public PropietariosController(IPropietarioService propietarioService, IMapper mapper)
    {
        _propietarioService = propietarioService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<PropietarioResource>> GetAllAsync()
    {
        var propietarios = await _propietarioService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Propietario>, IEnumerable<PropietarioResource>>(propietarios);
        
        return resources;
    }
}