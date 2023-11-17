using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Resources;
using AutoYa_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AutoYa_Backend.AutoYa.Controllers;

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
        // Obtener datos de alquileres desde el servicio
        var alquileres = await _alquilerService.ListAsync();

        // Imprimir datos de alquileres
        Console.WriteLine("Datos de Alquileres:");
        foreach (var alquiler in alquileres)
        {
            Console.WriteLine($"Id: {alquiler.Id}, Estado: {alquiler.Estado}, Fecha Inicio: {alquiler.Fecha_inicio}, Fecha Fin: {alquiler.Fecha_fin}, Propietario ID: {alquiler.PropietarioId}, Arrendatario ID: {alquiler.ArrendatarioId}, Vehiculo ID: {alquiler.VehiculoId}");
        }

        // Mapear los datos a recursos
        var resources = _mapper.Map<IEnumerable<Alquiler>, IEnumerable<AlquilerResource>>(alquileres);

        // Imprimir datos de resources
        Console.WriteLine("\nDatos de Resources:");
        foreach (var resource in resources)
        {
            Console.WriteLine($"Id: {resource.Id}, Estado: {resource.Estado}, Fecha Inicio: {resource.Fecha_inicio}, Fecha Fin: {resource.Fecha_fin}, Propietario ID: {resource.PropietarioId}, Arrendatario ID: {resource.ArrendatarioId}, Vehiculo ID: {resource.VehiculoId}");
        }
        
        
        
        // Retornar los recursos
        return resources;
    }

    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveAlquilerResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
    
        // Registros de depuración
        Console.WriteLine($"Resource values before mapping: Estado={resource.Estado}, FechaInicio={resource.Fecha_inicio}, FechaFin={resource.Fecha_fin}, Costo={resource.Costo_total}");

        
        var alquiler = _mapper.Map<SaveAlquilerResource, Alquiler>(resource);
    
        // Registros de depuración
        Console.WriteLine($"Resource values after mapping: Estado={resource.Estado}, FechaInicio={resource.Fecha_inicio}, FechaFin={resource.Fecha_fin}, Costo={resource.Costo_total}");

        
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
