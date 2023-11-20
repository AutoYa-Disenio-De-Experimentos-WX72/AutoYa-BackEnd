using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Resources;
using AutoYa_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AutoYa_Backend.AutoYa.Controllers;

/// <summary>
/// Controlador para gestionar operaciones CRUD en arrendatarios.
/// </summary>
[ApiController]
[Route("/api/v1/[controller]")]
public class ArrendatariosController : ControllerBase
{
    private readonly IArrendatarioService _arrendatarioService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor de la clase ArrendatariosController.
    /// </summary>
    /// <param name="arrendatarioService">Servicio de arrendatarios.</param>
    /// <param name="mapper">Instancia de AutoMapper.</param>
    public ArrendatariosController(IArrendatarioService arrendatarioService, IMapper mapper)
    {
        _arrendatarioService = arrendatarioService;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Obtiene todos los arrendatarios.
    /// </summary>
    /// <returns>Una colección de recursos de arrendatarios.</returns>
    [HttpGet]
    public async Task<IEnumerable<ArrendatarioResource>> GetAllAsync()
    {
        var arrendatarios = await _arrendatarioService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Arrendatario>, IEnumerable<ArrendatarioResource>>(arrendatarios);
        
        return resources;
    }

    /// <summary>
    /// Crea un nuevo arrendatario.
    /// </summary>
    /// <param name="resource">Datos del arrendatario a crear.</param>
    /// <returns>Una acción HTTP que indica el resultado de la operación.</returns>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveArrendatarioResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        // Aquí debes manejar el archivo, guardarlo y obtener la ruta o el identificador
        // string rutaArchivo = GuardarArchivo(resource.AntecedentesPenalesPdf);
        
        var arrendatario = _mapper.Map<SaveArrendatarioResource, Arrendatario>(resource);
        
        // Asigna la ruta o identificador del archivo a la propiedad correspondiente
        // category.AntecedentesPenalesPdfPath = rutaArchivo;
        
        var result = await _arrendatarioService.SaveAsync(arrendatario);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var arrendatarioResource = _mapper.Map<Arrendatario, ArrendatarioResource>(result.Resource);
        
        return Ok(arrendatarioResource);
    }

    /// <summary>
    /// Actualiza un arrendatario existente.
    /// </summary>
    /// <param name="id">Identificador del arrendatario a actualizar.</param>
    /// <param name="resource">Datos actualizados del arrendatario.</param>
    /// <returns>Una acción HTTP que indica el resultado de la operación.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveArrendatarioResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var arrendatario = _mapper.Map<SaveArrendatarioResource, Arrendatario>(resource);
        var result = await _arrendatarioService.UpdateAsync(id, arrendatario);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var arrendatarioResource = _mapper.Map<Arrendatario, ArrendatarioResource>(result.Resource);
        
        return Ok(arrendatarioResource);
    }

    /// <summary>
    /// Elimina un arrendatario existente.
    /// </summary>
    /// <param name="id">Identificador del arrendatario a eliminar.</param>
    /// <returns>Una acción HTTP que indica el resultado de la operación.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _arrendatarioService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var arrendatarioResource = _mapper.Map<Arrendatario, ArrendatarioResource>(result.Resource);
        
        return Ok(arrendatarioResource);
    }
}