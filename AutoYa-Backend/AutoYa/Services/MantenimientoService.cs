using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;
using AutoYa_Backend.Shared.Persistence.Repositories;

namespace AutoYa_Backend.AutoYa.Services;

public class MantenimientoService : IMantenimientoService
{
    private readonly IMantenimientoRepository _mantenimientoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MantenimientoService(IMantenimientoRepository mantenimientoRepository, IUnitOfWork unitOfWork)
        {
            _mantenimientoRepository = mantenimientoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Mantenimiento>> ListAsync()
        {
            return await _mantenimientoRepository.ListAsync();
        }

        public async Task<IEnumerable<Mantenimiento>> ListByPropietarioIdAsync(int propietarioId)
        {
            return await _mantenimientoRepository.FindByPropietarioIdAsync(propietarioId);
        }

        public async Task<IEnumerable<Mantenimiento>> ListByArrendatarioIdAsync(int arrendatarioId)
        {
            return await _mantenimientoRepository.FindByArrendatarioIdAsync(arrendatarioId);
        }

        public async Task<MantenimientoResponse> SaveAsync(Mantenimiento mantenimiento)
        {
            try
            {
                await _mantenimientoRepository.AddAsync(mantenimiento);
                await _unitOfWork.CompleteAsync();
                return new MantenimientoResponse(mantenimiento);
            }
            catch (Exception e)
            {
                return new MantenimientoResponse($"An error occurred while saving the mantenimiento: {e.Message}");
            }
        }

        public async Task<MantenimientoResponse> UpdateAsync(int mantenimientoId, Mantenimiento mantenimiento)
        {
            var existingMantenimiento = await _mantenimientoRepository.FindByIdAsync(mantenimientoId);
            if (existingMantenimiento == null)
                return new MantenimientoResponse("Mantenimiento not found.");

            existingMantenimiento.TipoProblema = mantenimiento.TipoProblema;
            existingMantenimiento.Titulo = mantenimiento.Titulo;
            existingMantenimiento.Descripcion = mantenimiento.Descripcion;
            existingMantenimiento.UrlImagen = mantenimiento.UrlImagen;

            try
            {
                _mantenimientoRepository.Update(existingMantenimiento);
                await _unitOfWork.CompleteAsync();
                return new MantenimientoResponse(existingMantenimiento);
            }
            catch (Exception e)
            {
                return new MantenimientoResponse($"An error occurred while updating the mantenimiento: {e.Message}");
            }
        }

        public async Task<MantenimientoResponse> DeleteAsync(int mantenimientoId)
        {
            var existingMantenimiento = await _mantenimientoRepository.FindByIdAsync(mantenimientoId);
            if (existingMantenimiento == null)
                return new MantenimientoResponse("Mantenimiento not found.");

            try
            {
                _mantenimientoRepository.Remove(existingMantenimiento);
                await _unitOfWork.CompleteAsync();
                return new MantenimientoResponse(existingMantenimiento);
            }
            catch (Exception e)
            {
                return new MantenimientoResponse($"An error occurred while deleting the mantenimiento: {e.Message}");
            }
        }
}