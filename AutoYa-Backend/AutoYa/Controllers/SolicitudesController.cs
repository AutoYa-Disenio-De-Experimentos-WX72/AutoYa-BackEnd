using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Resources;
using AutoYa_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AutoYa_Backend.AutoYa.Controllers;

/// <summary>
/// Controlador para gestionar operaciones CRUD en solicitudes.
/// </summary>
[ApiController]
    [Route("/api/v1/[controller]")]
    public class SolicitudesController : ControllerBase
    {
        private readonly ISolicitudService _solicitudService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor de la clase SolicitudesController.
        /// </summary>
        /// <param name="solicitudService">Servicio de solicitudes.</param>
        /// <param name="mapper">Instancia de AutoMapper.</param>
        public SolicitudesController(ISolicitudService solicitudService, IMapper mapper)
        {
            _solicitudService = solicitudService;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todas las solicitudes.
        /// </summary>
        /// <returns>Una colección de recursos de solicitudes.</returns>
        [HttpGet]
        public async Task<IEnumerable<SolicitudResource>> GetAllAsync()
        {
            var solicitudes = await _solicitudService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Solicitud>, IEnumerable<SolicitudResource>>(solicitudes);

            return resources;
        }

        /// <summary>
        /// Crea una nueva solicitud.
        /// </summary>
        /// <param name="resource">Datos de la solicitud a crear.</param>
        /// <returns>Una acción HTTP que indica el resultado de la operación.</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSolicitudResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var solicitud = _mapper.Map<SaveSolicitudResource, Solicitud>(resource);

            var result = await _solicitudService.SaveAsync(solicitud);

            if (!result.Success)
                return BadRequest(result.Message);

            var solicitudResource = _mapper.Map<Solicitud, SolicitudResource>(result.Resource);

            return Ok(solicitudResource);
        }

        /// <summary>
        /// Actualiza una solicitud existente.
        /// </summary>
        /// <param name="id">Identificador de la solicitud a actualizar.</param>
        /// <param name="resource">Datos actualizados de la solicitud.</param>
        /// <returns>Una acción HTTP que indica el resultado de la operación.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSolicitudResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var solicitud = _mapper.Map<SaveSolicitudResource, Solicitud>(resource);
            var result = await _solicitudService.UpdateAsync(id, solicitud);

            if (!result.Success)
                return BadRequest(result.Message);

            var solicitudResource = _mapper.Map<Solicitud, SolicitudResource>(result.Resource);

            return Ok(solicitudResource);
        }

        /// <summary>
        /// Elimina una solicitud existente.
        /// </summary>
        /// <param name="id">Identificador de la solicitud a eliminar.</param>
        /// <returns>Una acción HTTP que indica el resultado de la operación.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _solicitudService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var solicitudResource = _mapper.Map<Solicitud, SolicitudResource>(result.Resource);

            return Ok(solicitudResource);
        }
    }