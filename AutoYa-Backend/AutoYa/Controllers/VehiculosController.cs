using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Resources;
using AutoYa_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AutoYa_Backend.AutoYa.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class VehiculosController : ControllerBase
{
    private readonly IVehiculoService _vehiculoService;
    private readonly IMapper _mapper;

    public VehiculosController(IVehiculoService vehiculoService, IMapper mapper)
    {
        _vehiculoService = vehiculoService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<VehiculoResource>> GetAllAsync()
    {
        var vehiculos = await _vehiculoService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Vehiculo>, IEnumerable<VehiculoResource>>(vehiculos);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveVehiculoResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var vehiculo = _mapper.Map<SaveVehiculoResource, Vehiculo>(resource);

        vehiculo.EstadoRenta = "AVAILABLE";
        vehiculo.ArrendatarioId = null;
        vehiculo.AlquilerId = null;
        
        var result = await _vehiculoService.SaveAsync(vehiculo);

        if (!result.Success)
            return BadRequest(result.Message);

        var vehiculoResource = _mapper.Map<Vehiculo, VehiculoResource>(result.Resource);

        return Ok(vehiculoResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveVehiculoResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var vehiculo = _mapper.Map<SaveVehiculoResource, Vehiculo>(resource);
        var result = await _vehiculoService.UpdateAsync(id, vehiculo);

        if (!result.Success)
            return BadRequest(result.Message);

        var vehiculoResource = _mapper.Map<Vehiculo, VehiculoResource>(result.Resource);

        return Ok(vehiculoResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _vehiculoService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var vehiculoResource = _mapper.Map<Vehiculo, VehiculoResource>(result.Resource);

        return Ok(vehiculoResource);
    }
}