using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;
using AutoYa_Backend.Shared.Persistence.Repositories;

namespace AutoYa_Backend.AutoYa.Services;

public class AlquilerService : IAlquilerService
{
    private readonly IAlquilerRepository _alquilerRepository;
    private readonly IUnitOfWork _unitOfWork;

        public AlquilerService(IAlquilerRepository alquilerRepository, IUnitOfWork unitOfWork)
        {
            _alquilerRepository = alquilerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Alquiler>> ListAsync()
        {
            return await _alquilerRepository.ListAsync();
        }

        public async Task<IEnumerable<Alquiler>> ListByVehiculoIdAsync(int vehiculoId)
        {
            return await _alquilerRepository.FindByVehiculoIdAsync(vehiculoId);
        }

        public async Task<IEnumerable<Alquiler>> ListByPropietarioIdAsync(int propietarioId)
        {
            return await _alquilerRepository.FindByPropietarioIdAsync(propietarioId);
        }

        public async Task<IEnumerable<Alquiler>> ListByArrendatarioIdAsync(int arrendatarioId)
        {
            return await _alquilerRepository.FindByArrendatarioIdAsync(arrendatarioId);
        }

        public async Task<IEnumerable<Alquiler>> ListBySolicitudIdAsync(int solicitudId)
        {
            return await _alquilerRepository.FindBySolicitudIdAsync(solicitudId);
        }

        public async Task<AlquilerResponse> SaveAsync(Alquiler alquiler)
        {
            try
            {
                await _alquilerRepository.AddAsync(alquiler);
                await _unitOfWork.CompleteAsync();
                return new AlquilerResponse(alquiler);
            }
            catch (Exception e)
            {
                return new AlquilerResponse($"An error occurred while saving the alquiler: {e.Message}");
            }
        }

        public async Task<AlquilerResponse> UpdateAsync(int alquilerId, Alquiler alquiler)
        {
            var existingAlquiler = await _alquilerRepository.FindByIdAsync(alquilerId);
            if (existingAlquiler == null)
                return new AlquilerResponse("Alquiler not found.");

            existingAlquiler.Estado = alquiler.Estado;
            existingAlquiler.Fecha_inicio = alquiler.Fecha_inicio;
            existingAlquiler.Fecha_fin = alquiler.Fecha_fin;
            existingAlquiler.Costo_total = alquiler.Costo_total;

            try
            {
                _alquilerRepository.Update(existingAlquiler);
                await _unitOfWork.CompleteAsync();
                return new AlquilerResponse(existingAlquiler);
            }
            catch (Exception e)
            {
                return new AlquilerResponse($"An error occurred while updating the alquiler: {e.Message}");
            }
        }

        public async Task<AlquilerResponse> DeleteAsync(int alquilerId)
        {
            var existingAlquiler = await _alquilerRepository.FindByIdAsync(alquilerId);
            if (existingAlquiler == null)
                return new AlquilerResponse("Alquiler not found.");

            try
            {
                _alquilerRepository.Remove(existingAlquiler);
                await _unitOfWork.CompleteAsync();
                return new AlquilerResponse(existingAlquiler);
            }
            catch (Exception e)
            {
                return new AlquilerResponse($"An error occurred while deleting the alquiler: {e.Message}");
            }
        }
}