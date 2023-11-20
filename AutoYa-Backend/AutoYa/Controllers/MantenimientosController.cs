using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Resources;
using AutoYa_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AutoYa_Backend.AutoYa.Controllers;

/// <summary>
/// Controlador para gestionar operaciones CRUD en mantenimientos.
/// </summary>
[ApiController]
    [Route("/api/v1/[controller]")]
    public class MantenimientosController : ControllerBase
    {
        private readonly IMantenimientoService _mantenimientoService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor de la clase MantenimientosController.
        /// </summary>
        /// <param name="mantenimientoService">Servicio de mantenimientos.</param>
        /// <param name="mapper">Instancia de AutoMapper.</param>
        public MantenimientosController(IMantenimientoService mantenimientoService, IMapper mapper)
        {
            _mantenimientoService = mantenimientoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todos los mantenimientos.
        /// </summary>
        /// <returns>Una colección de recursos de mantenimientos.</returns>
        [HttpGet]
        public async Task<IEnumerable<MantenimientoResource>> GetAllAsync()
        {
            var mantenimientos = await _mantenimientoService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Mantenimiento>, IEnumerable<MantenimientoResource>>(mantenimientos);

            return resources;
        }

        /// <summary>
        /// Crea un nuevo mantenimiento.
        /// </summary>
        /// <param name="resource">Datos del mantenimiento a crear.</param>
        /// <returns>Una acción HTTP que indica el resultado de la operación.</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveMantenimientoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var mantenimiento = _mapper.Map<SaveMantenimientoResource, Mantenimiento>(resource);

            var result = await _mantenimientoService.SaveAsync(mantenimiento);

            if (!result.Success)
                return BadRequest(result.Message);

            var mantenimientoResource = _mapper.Map<Mantenimiento, MantenimientoResource>(result.Resource);

            return Ok(mantenimientoResource);
        }

        /// <summary>
        /// Actualiza un mantenimiento existente.
        /// </summary>
        /// <param name="id">Identificador del mantenimiento a actualizar.</param>
        /// <param name="resource">Datos actualizados del mantenimiento.</param>
        /// <returns>Una acción HTTP que indica el resultado de la operación.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMantenimientoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var mantenimiento = _mapper.Map<SaveMantenimientoResource, Mantenimiento>(resource);
            
            var result = await _mantenimientoService.UpdateAsync(id, mantenimiento);

            if (!result.Success)
                return BadRequest(result.Message);

            var mantenimientoResource = _mapper.Map<Mantenimiento, MantenimientoResource>(result.Resource);

            return Ok(mantenimientoResource);
        }

        /// <summary>
        /// Elimina un mantenimiento existente.
        /// </summary>
        /// <param name="id">Identificador del mantenimiento a eliminar.</param>
        /// <returns>Una acción HTTP que indica el resultado de la operación.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _mantenimientoService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var mantenimientoResource = _mapper.Map<Mantenimiento, MantenimientoResource>(result.Resource);

            return Ok(mantenimientoResource);
        }
    }