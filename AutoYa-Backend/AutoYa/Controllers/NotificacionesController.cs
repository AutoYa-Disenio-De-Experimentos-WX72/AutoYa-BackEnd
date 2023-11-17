using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Resources;
using AutoYa_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AutoYa_Backend.AutoYa.Controllers;

[ApiController]
    [Route("/api/v1/[controller]")]
    public class NotificacionesController : ControllerBase
    {
        private readonly INotificacionService _notificacionService;
        private readonly IMapper _mapper;

        public NotificacionesController(INotificacionService notificacionService, IMapper mapper)
        {
            _notificacionService = notificacionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<NotificacionResource>> GetAllAsync()
        {
            var notificaciones = await _notificacionService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Notificacion>, IEnumerable<NotificacionResource>>(notificaciones);

            return resources;
        }

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