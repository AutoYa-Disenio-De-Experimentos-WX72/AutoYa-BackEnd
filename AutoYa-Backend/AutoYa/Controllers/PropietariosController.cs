using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Resources;
using AutoYa_Backend.Shared.Extensions;
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
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePropietarioResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
    
        var propietario = _mapper.Map<SavePropietarioResource, Propietario>(resource);
    
        var result = await _propietarioService.SaveAsync(propietario);
    
        if (!result.Success)
            return BadRequest(result.Message);
    
        var propietarioResource = _mapper.Map<Propietario, PropietarioResource>(result.Resource);
    
        return Ok(propietarioResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePropietarioResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
    
        var propietario = _mapper.Map<SavePropietarioResource, Propietario>(resource);
        var result = await _propietarioService.UpdateAsync(id, propietario);
    
        if (!result.Success)
            return BadRequest(result.Message);
    
        var propietarioResource = _mapper.Map<Propietario, PropietarioResource>(result.Resource);
    
        return Ok(propietarioResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _propietarioService.DeleteAsync(id);
    
        if (!result.Success)
            return BadRequest(result.Message);
    
        var propietarioResource = _mapper.Map<Propietario, PropietarioResource>(result.Resource);
    
        return Ok(propietarioResource);
    }

}