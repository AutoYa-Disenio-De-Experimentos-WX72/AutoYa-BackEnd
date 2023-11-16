using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Resources;
using AutoYa_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AutoYa_Backend.AutoYa.Controllers;

[ApiController]
    [Route("/api/v1/[controller]")]
    public class SolicitudesController : ControllerBase
    {
        private readonly ISolicitudService _solicitudService;
        private readonly IMapper _mapper;

        public SolicitudesController(ISolicitudService solicitudService, IMapper mapper)
        {
            _solicitudService = solicitudService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SolicitudResource>> GetAllAsync()
        {
            var solicitudes = await _solicitudService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Solicitud>, IEnumerable<SolicitudResource>>(solicitudes);

            return resources;
        }

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