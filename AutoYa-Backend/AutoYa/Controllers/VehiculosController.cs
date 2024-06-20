using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Resources;
using AutoYa_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AutoYa_Backend.AutoYa.Controllers;

/// <summary>
/// Controlador para gestionar operaciones CRUD en vehículos.
/// </summary>
[ApiController]
[Route("/api/v1/[controller]")]
public class VehiculosController : ControllerBase
{
    private readonly IVehiculoService _vehiculoService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor de la clase VehiculosController.
    /// </summary>
    /// <param name="vehiculoService">Servicio de vehículos.</param>
    /// <param name="mapper">Instancia de AutoMapper.</param>
    public VehiculosController(IVehiculoService vehiculoService, IMapper mapper)
    {
        _vehiculoService = vehiculoService;
        _mapper = mapper;
    }

    /// <summary>
    /// Obtiene todos los vehículos.
    /// </summary>
    /// <returns>Una colección de recursos de vehículos.</returns>
    [HttpGet]
    public async Task<IEnumerable<VehiculoResource>> GetAllAsync()
    {
        var vehiculos = await _vehiculoService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Vehiculo>, IEnumerable<VehiculoResource>>(vehiculos);

        return resources;
    }

    /// <summary>
    /// Crea un nuevo vehículo.
    /// </summary>
    /// <param name="resource">Datos del vehículo a crear.</param>
    /// <returns>Una acción HTTP que indica el resultado de la operación.</returns>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveVehiculoResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var vehiculo = _mapper.Map<SaveVehiculoResource, Vehiculo>(resource);

        vehiculo.EstadoRenta = "Disponible";
        vehiculo.ArrendatarioId = null;
        vehiculo.AlquilerId = null;
        
        var result = await _vehiculoService.SaveAsync(vehiculo);

        if (!result.Success)
            return BadRequest(result.Message);

        var vehiculoResource = _mapper.Map<Vehiculo, VehiculoResource>(result.Resource);

        return Ok(vehiculoResource);
    }

    /// <summary>
    /// Actualiza un vehículo existente.
    /// </summary>
    /// <param name="id">Identificador del vehículo a actualizar.</param>
    /// <param name="resource">Datos actualizados del vehículo.</param>
    /// <returns>Una acción HTTP que indica el resultado de la operación.</returns>
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

    /// <summary>
    /// Elimina un vehículo existente.
    /// </summary>
    /// <param name="id">Identificador del vehículo a eliminar.</param>
    /// <returns>Una acción HTTP que indica el resultado de la operación.</returns>
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