using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Resources;
using AutoYa_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AutoYa_Backend.AutoYa.Controllers;

[ApiController]
    [Route("/api/v1/[controller]")]
    public class MantenimientosController : ControllerBase
    {
        private readonly IMantenimientoService _mantenimientoService;
        private readonly IMapper _mapper;

        public MantenimientosController(IMantenimientoService mantenimientoService, IMapper mapper)
        {
            _mantenimientoService = mantenimientoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MantenimientoResource>> GetAllAsync()
        {
            var mantenimientos = await _mantenimientoService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Mantenimiento>, IEnumerable<MantenimientoResource>>(mantenimientos);

            return resources;
        }

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