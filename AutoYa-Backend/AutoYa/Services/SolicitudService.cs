using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;
using AutoYa_Backend.Shared.Persistence.Repositories;

namespace AutoYa_Backend.AutoYa.Services;

/// <summary>
/// Servicio para gestionar las operaciones CRUD de solicitudes.
/// </summary>
public class SolicitudService : ISolicitudService
{
    private readonly ISolicitudRepository _solicitudRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Inicializa una nueva instancia del servicio de solicitudes, inyectando las dependencias necesarias.
        /// </summary>
        /// <param name="solicitudRepository">Repositorio para operaciones de solicitudes.</param>
        /// <param name="unitOfWork">Unidad de trabajo para coordinar la ejecución de operaciones transaccionales.</param>
    
        public SolicitudService(ISolicitudRepository solicitudRepository, IUnitOfWork unitOfWork)
        {
            _solicitudRepository = solicitudRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtiene una lista asincrónica de todas las solicitudes.
        /// </summary>
        /// <returns>Una lista de solicitudes.</returns>
        public async Task<IEnumerable<Solicitud>> ListAsync()
        {
            return await _solicitudRepository.ListAsync();
        }

        /// <summary>
        /// Obtiene una lista asincrónica de solicitudes por identificador de alquiler.
        /// </summary>
        /// <param name="alquilerId">Identificador del alquiler asociado a las solicitudes.</param>
        /// <returns>Una lista de solicitudes asociadas al alquiler.</returns>
        public async Task<IEnumerable<Solicitud>> ListByAlquilerIdAsync(int alquilerId)
        {
            return await _solicitudRepository.FindByAlquilerIdAsync(alquilerId);
        }

        /// <summary>
        /// Guarda una solicitud de forma asincrónica.
        /// </summary>
        /// <param name="solicitud">Datos de la solicitud a guardar.</param>
        /// <returns>Respuesta indicando el resultado de la operación de guardado.</returns>
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

        /// <summary>
        /// Actualiza una solicitud existente de forma asincrónica.
        /// </summary>
        /// <param name="solicitudId">Identificador de la solicitud a actualizar.</param>
        /// <param name="solicitud">Datos actualizados de la solicitud.</param>
        /// <returns>Respuesta indicando el resultado de la operación de actualización.</returns>
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

        /// <summary>
        /// Elimina una solicitud existente de forma asincrónica.
        /// </summary>
        /// <param name="solicitudId">Identificador de la solicitud a eliminar.</param>
        /// <returns>Respuesta indicando el resultado de la operación de eliminación.</returns>
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