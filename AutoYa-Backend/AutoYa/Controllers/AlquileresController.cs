using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Resources;
using AutoYa_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AutoYa_Backend.AutoYa.Controllers;

//CONTINUAR MODIFICANDO ALQUILER CONTROLLER Y SOLICITUD CONTROLER PARA QUE SE ACTUALICEN DATOS DE VEHICULO Y SE CREE SOLICITUD.

[ApiController]
[Route("/api/v1/[controller]")]
public class AlquileresController : ControllerBase
{
    private readonly IAlquilerService _alquilerService;
    private readonly IMapper _mapper;

    public AlquileresController(IAlquilerService alquilerService, IMapper mapper)
    {
        _alquilerService = alquilerService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<AlquilerResource>> GetAllAsync()
    {
        var alquileres = await _alquilerService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Alquiler>, IEnumerable<AlquilerResource>>(alquileres);
        
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveAlquilerResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
    
        var alquiler = _mapper.Map<SaveAlquilerResource, Alquiler>(resource);
    
        var result = await _alquilerService.SaveAsync(alquiler);
    
        if (!result.Success)
            return BadRequest(result.Message);
    
        var alquilerResource = _mapper.Map<Alquiler, AlquilerResource>(result.Resource);
    
        return Ok(alquilerResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAlquilerResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
    
        var alquiler = _mapper.Map<SaveAlquilerResource, Alquiler>(resource);
        var result = await _alquilerService.UpdateAsync(id, alquiler);
    
        if (!result.Success)
            return BadRequest(result.Message);
    
        var alquilerResource = _mapper.Map<Alquiler, AlquilerResource>(result.Resource);
    
        return Ok(alquilerResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _alquilerService.DeleteAsync(id);
    
        if (!result.Success)
            return BadRequest(result.Message);
    
        var alquilerResource = _mapper.Map<Alquiler, AlquilerResource>(result.Resource);
    
        return Ok(alquilerResource);
    }
}
