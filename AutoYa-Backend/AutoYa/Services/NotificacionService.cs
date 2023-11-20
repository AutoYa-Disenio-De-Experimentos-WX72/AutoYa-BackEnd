using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;
using AutoYa_Backend.Shared.Persistence.Repositories;

namespace AutoYa_Backend.AutoYa.Services;

/// <summary>
/// Servicio que ofrece métodos para la gestión de notificaciones.
/// </summary>
public class NotificacionService : INotificacionService
{
    private readonly INotificacionRepository _notificacionRepository;
        private readonly IUnitOfWork _unitOfWork;


        // Declaraciones de los repositorios y unidad de trabajo (UnitOfWork)
        
        /// <summary>
        /// Inicializa una nueva instancia del servicio de notificaciones, inyectando las dependencias requeridas.
        /// </summary>
        /// <param name="notificacionRepository">Repositorio para operaciones de notificación.</param>
        /// <param name="unitOfWork">Unidad de trabajo para coordinar operaciones que afectan a múltiples repositorios.</param>
        public NotificacionService(INotificacionRepository notificacionRepository, IUnitOfWork unitOfWork)
        {
            _notificacionRepository = notificacionRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtiene todas las notificaciones de manera asincrónica.
        /// </summary>
        /// <returns>Una colección de notificaciones.</returns>
        public async Task<IEnumerable<Notificacion>> ListAsync()
        {
            return await _notificacionRepository.ListAsync();
        }

        /// <summary>
        /// Obtiene todas las notificaciones asociadas a un propietario específico de manera asincrónica.
        /// </summary>
        /// <param name="propietarioId">Identificador del propietario.</param>
        /// <returns>Una colección de notificaciones.</returns>
        public async Task<IEnumerable<Notificacion>> ListByPropietarioIdAsync(int propietarioId)
        {
            return await _notificacionRepository.FindByPropietarioIdAsync(propietarioId);
        }

        /// <summary>
        /// Obtiene todas las notificaciones asociadas a un arrendatario específico de manera asincrónica.
        /// </summary>
        /// <param name="arrendatarioId">Identificador del arrendatario.</param>
        /// <returns>Una colección de notificaciones.</returns>
        public async Task<IEnumerable<Notificacion>> ListByArrendatarioIdAsync(int arrendatarioId)
        {
            return await _notificacionRepository.FindByArrendatarioIdAsync(arrendatarioId);
        }

        /// <summary>
        /// Guarda una notificación de manera asincrónica.
        /// </summary>
        /// <param name="notificacion">Datos de la notificación a guardar.</param>
        /// <returns>Una respuesta con la notificación guardada o un mensaje de error.</returns>
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

        /// <summary>
        /// Actualiza una notificación existente de manera asincrónica.
        /// </summary>
        /// <param name="notificacionId">Identificador de la notificación a actualizar.</param>
        /// <param name="notificacion">Datos de la notificación con las actualizaciones.</param>
        /// <returns>Una respuesta con la notificación actualizada o un mensaje de error.</returns>
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

        /// <summary>
        /// Elimina una notificación de manera asincrónica.
        /// </summary>
        /// <param name="notificacionId">Identificador de la notificación a eliminar.</param>
        /// <returns>Una respuesta con la notificación eliminada o un mensaje de error.</returns>
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