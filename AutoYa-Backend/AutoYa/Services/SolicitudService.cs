using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;
using AutoYa_Backend.Shared.Persistence.Repositories;

namespace AutoYa_Backend.AutoYa.Services;

public class SolicitudService : ISolicitudService
{
    private readonly ISolicitudRepository _solicitudRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SolicitudService(ISolicitudRepository solicitudRepository, IUnitOfWork unitOfWork)
        {
            _solicitudRepository = solicitudRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Solicitud>> ListAsync()
        {
            return await _solicitudRepository.ListAsync();
        }

        public async Task<IEnumerable<Solicitud>> ListByAlquilerIdAsync(int alquilerId)
        {
            return await _solicitudRepository.FindByAlquilerIdAsync(alquilerId);
        }

        public async Task<SolicitudResponse> SaveAsync(Solicitud solicitud)
        {
            try
            {
                await _solicitudRepository.AddAsync(solicitud);
                await _unitOfWork.CompleteAsync();
                return new SolicitudResponse(solicitud);
            }
            catch (Exception e)
            {
                return new SolicitudResponse($"An error occurred while saving the solicitud: {e.Message}");
            }
        }

        public async Task<SolicitudResponse> UpdateAsync(int solicitudId, Solicitud solicitud)
        {
            var existingSolicitud = await _solicitudRepository.FindByIdAsync(solicitudId);
            if (existingSolicitud == null)
                return new SolicitudResponse("Solicitud not found.");

            existingSolicitud.Body = solicitud.Body;

            try
            {
                _solicitudRepository.Update(existingSolicitud);
                await _unitOfWork.CompleteAsync();
                return new SolicitudResponse(existingSolicitud);
            }
            catch (Exception e)
            {
                return new SolicitudResponse($"An error occurred while updating the solicitud: {e.Message}");
            }
        }

        public async Task<SolicitudResponse> DeleteAsync(int solicitudId)
        {
            var existingSolicitud = await _solicitudRepository.FindByIdAsync(solicitudId);
            if (existingSolicitud == null)
                return new SolicitudResponse("Solicitud not found.");

            try
            {
                _solicitudRepository.Remove(existingSolicitud);
                await _unitOfWork.CompleteAsync();
                return new SolicitudResponse(existingSolicitud);
            }
            catch (Exception e)
            {
                return new SolicitudResponse($"An error occurred while deleting the solicitud: {e.Message}");
            }
        }
}