using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;
using AutoYa_Backend.Shared.Persistence.Repositories;

namespace AutoYa_Backend.AutoYa.Services;

public class NotificacionService : INotificacionService
{
    private readonly INotificacionRepository _notificacionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NotificacionService(INotificacionRepository notificacionRepository, IUnitOfWork unitOfWork)
        {
            _notificacionRepository = notificacionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Notificacion>> ListAsync()
        {
            return await _notificacionRepository.ListAsync();
        }

        public async Task<IEnumerable<Notificacion>> ListByPropietarioIdAsync(int propietarioId)
        {
            return await _notificacionRepository.FindByPropietarioIdAsync(propietarioId);
        }

        public async Task<IEnumerable<Notificacion>> ListByArrendatarioIdAsync(int arrendatarioId)
        {
            return await _notificacionRepository.FindByArrendatarioIdAsync(arrendatarioId);
        }

        public async Task<NotificacionResponse> SaveAsync(Notificacion notificacion)
        {
            try
            {
                await _notificacionRepository.AddAsync(notificacion);
                await _unitOfWork.CompleteAsync();
                return new NotificacionResponse(notificacion);
            }
            catch (Exception e)
            {
                return new NotificacionResponse($"An error occurred while saving the notificacion: {e.Message}");
            }
        }

        public async Task<NotificacionResponse> UpdateAsync(int notificacionId, Notificacion notificacion)
        {
            var existingNotificacion = await _notificacionRepository.FindByIdAsync(notificacionId);
            if (existingNotificacion == null)
                return new NotificacionResponse("Notificacion not found.");

            existingNotificacion.Body = notificacion.Body;

            try
            {
                existingNotificacion.ArrendatarioId = notificacion.ArrendatarioId;
                existingNotificacion.PropietarioId = notificacion.PropietarioId;
                
                _notificacionRepository.Update(existingNotificacion);
                await _unitOfWork.CompleteAsync();
                return new NotificacionResponse(existingNotificacion);
            }
            catch (Exception e)
            {
                return new NotificacionResponse($"An error occurred while updating the notificacion: {e.Message}");
            }
        }

        public async Task<NotificacionResponse> DeleteAsync(int notificacionId)
        {
            var existingNotificacion = await _notificacionRepository.FindByIdAsync(notificacionId);
            if (existingNotificacion == null)
                return new NotificacionResponse("Notificacion not found.");

            try
            {
                _notificacionRepository.Remove(existingNotificacion);
                await _unitOfWork.CompleteAsync();
                return new NotificacionResponse(existingNotificacion);
            }
            catch (Exception e)
            {
                return new NotificacionResponse($"An error occurred while deleting the notificacion: {e.Message}");
            }
        }
}