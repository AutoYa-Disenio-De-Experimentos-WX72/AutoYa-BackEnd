using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Resources;
using AutoYa_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AutoYa_Backend.AutoYa.Controllers;

/// <summary>
/// Controlador para gestionar operaciones CRUD en notificaciones.
/// </summary>
[ApiController]
    [Route("/api/v1/[controller]")]
    public class NotificacionesController : ControllerBase
    {
        private readonly INotificacionService _notificacionService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor de la clase NotificacionesController.
        /// </summary>
        /// <param name="notificacionService">Servicio de notificaciones.</param>
        /// <param name="mapper">Instancia de AutoMapper.</param>
        public NotificacionesController(INotificacionService notificacionService, IMapper mapper)
        {
            _notificacionService = notificacionService;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todas las notificaciones.
        /// </summary>
        /// <returns>Una colección de recursos de notificaciones.</returns>
        [HttpGet]
        public async Task<IEnumerable<NotificacionResource>> GetAllAsync()
        {
            var notificaciones = await _notificacionService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Notificacion>, IEnumerable<NotificacionResource>>(notificaciones);

            return resources;
        }

        /// <summary>
        /// Crea una nueva notificación.
        /// </summary>
        /// <param name="resource">Datos de la notificación a crear.</param>
        /// <returns>Una acción HTTP que indica el resultado de la operación.</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveNotificacionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var notificacion = _mapper.Map<SaveNotificacionResource, Notificacion>(resource);

            var result = await _notificacionService.SaveAsync(notificacion);

            if (!result.Success)
                return BadRequest(result.Message);

            var notificacionResource = _mapper.Map<Notificacion, NotificacionResource>(result.Resource);

            return Ok(notificacionResource);
        }

        /// <summary>
        /// Actualiza una notificación existente.
        /// </summary>
        /// <param name="id">Identificador de la notificación a actualizar.</param>
        /// <param name="resource">Datos actualizados de la notificación.</param>
        /// <returns>Una acción HTTP que indica el resultado de la operación.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveNotificacionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var notificacion = _mapper.Map<SaveNotificacionResource, Notificacion>(resource);

            var result = await _notificacionService.UpdateAsync(id, notificacion);

            if (!result.Success)
                return BadRequest(result.Message);

            var notificacionResource = _mapper.Map<Notificacion, NotificacionResource>(result.Resource);

            return Ok(notificacionResource);
        }

        /// <summary>
        /// Elimina una notificación existente.
        /// </summary>
        /// <param name="id">Identificador de la notificación a eliminar.</param>
        /// <returns>Una acción HTTP que indica el resultado de la operación.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _notificacionService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var notificacionResource = _mapper.Map<Notificacion, NotificacionResource>(result.Resource);

            return Ok(notificacionResource);
        }
    }