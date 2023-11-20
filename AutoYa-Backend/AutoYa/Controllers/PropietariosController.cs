using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Resources;
using AutoYa_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AutoYa_Backend.AutoYa.Controllers;

/// <summary>
/// Controlador para gestionar operaciones CRUD en propietarios.
/// </summary>
[ApiController]
[Route("/api/v1/[controller]")]
public class PropietariosController : ControllerBase
{
    private readonly IPropietarioService _propietarioService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor de la clase PropietariosController.
    /// </summary>
    /// <param name="propietarioService">Servicio de propietarios.</param>
    /// <param name="mapper">Instancia de AutoMapper.</param>
    public PropietariosController(IPropietarioService propietarioService, IMapper mapper)
    {
        _propietarioService = propietarioService;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Obtiene todos los propietarios.
    /// </summary>
    /// <returns>Una colección de recursos de propietarios.</returns>
    [HttpGet]
    public async Task<IEnumerable<PropietarioResource>> GetAllAsync()
    {
        var propietarios = await _propietarioService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Propietario>, IEnumerable<PropietarioResource>>(propietarios);
        
        return resources;
    }
    
    /// <summary>
    /// Crea un nuevo propietario.
    /// </summary>
    /// <param name="resource">Datos del propietario a crear.</param>
    /// <returns>Una acción HTTP que indica el resultado de la operación.</returns>
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

    /// <summary>
    /// Actualiza un propietario existente.
    /// </summary>
    /// <param name="id">Identificador del propietario a actualizar.</param>
    /// <param name="resource">Datos actualizados del propietario.</param>
    /// <returns>Una acción HTTP que indica el resultado de la operación.</returns>
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

    /// <summary>
    /// Elimina un propietario existente.
    /// </summary>
    /// <param name="id">Identificador del propietario a eliminar.</param>
    /// <returns>Una acción HTTP que indica el resultado de la operación.</returns>
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