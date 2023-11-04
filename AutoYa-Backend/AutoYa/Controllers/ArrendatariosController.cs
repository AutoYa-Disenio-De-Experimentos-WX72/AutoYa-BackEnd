using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Resources;
using Microsoft.AspNetCore.Mvc;

namespace AutoYa_Backend.AutoYa.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ArrendatariosController : ControllerBase
{
    private readonly IArrendatarioService _arrendatarioService;
    private readonly IMapper _mapper;

    public ArrendatariosController(IArrendatarioService arrendatarioService, IMapper mapper)
    {
        _arrendatarioService = arrendatarioService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<ArrendatarioResource>> GetAllAsync()
    {
        var arrendatarios = await _arrendatarioService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Arrendatario>, IEnumerable<ArrendatarioResource>>(arrendatarios);
        
        return resources;
    }
}