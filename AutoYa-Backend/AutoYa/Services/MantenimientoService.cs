using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Domain.Services.Communication;
using AutoYa_Backend.Shared.Persistence.Repositories;

namespace AutoYa_Backend.AutoYa.Services;

/// <summary>
/// Servicio que ofrece métodos para gestionar las operaciones CRUD de mantenimientos.
/// </summary>
public class MantenimientoService : IMantenimientoService
{
    private readonly IMantenimientoRepository _mantenimientoRepository;
        private readonly IUnitOfWork _unitOfWork;


        // Declaraciones de los repositorios y unidad de trabajo (UnitOfWork)
        
        /// <summary>
        /// Inicializa una nueva instancia del servicio de mantenimientos, inyectando las dependencias necesarias.
        /// </summary>
        /// <param name="mantenimientoRepository">Repositorio para operaciones de mantenimiento.</param>
        /// <param name="unitOfWork">Unidad de trabajo para operaciones que involucran múltiples repositorios.</param>
        public MantenimientoService(IMantenimientoRepository mantenimientoRepository, IUnitOfWork unitOfWork)
        {
            _mantenimientoRepository = mantenimientoRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtiene una lista asincrónica de todos los mantenimientos.
        /// </summary>
        /// <returns>Una lista de instancias de Mantenimiento.</returns>
        public async Task<IEnumerable<Mantenimiento>> ListAsync()
        {
            return await _mantenimientoRepository.ListAsync();
        }

        /// <summary>
        /// Obtiene una lista asincrónica de los mantenimientos asociados a un propietario específico.
        /// </summary>
        /// <param name="propietarioId">Identificador del propietario.</param>
        /// <returns>Una lista de instancias de Mantenimiento.</returns>
        public async Task<IEnumerable<Mantenimiento>> ListByPropietarioIdAsync(int propietarioId)
        {
            return await _mantenimientoRepository.FindByPropietarioIdAsync(propietarioId);
        }

        /// <summary>
        /// Obtiene una lista asincrónica de los mantenimientos asociados a un arrendatario específico.
        /// </summary>
        /// <param name="arrendatarioId">Identificador del arrendatario.</param>
        /// <returns>Una lista de instancias de Mantenimiento.</returns>
        public async Task<IEnumerable<Mantenimiento>> ListByArrendatarioIdAsync(int arrendatarioId)
        {
            return await _mantenimientoRepository.FindByArrendatarioIdAsync(arrendatarioId);
        }

        /// <summary>
        /// Guarda un mantenimiento de manera asincrónica en la base de datos.
        /// </summary>
        /// <param name="mantenimiento">Datos del mantenimiento a guardar.</param>
        /// <returns>Respuesta de la operación con el mantenimiento guardado o un error.</returns>
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

        /// <summary>
        /// Actualiza un mantenimiento existente de manera asincrónica en la base de datos.
        /// </summary>
        /// <param name="mantenimientoId">Identificador del mantenimiento a actualizar.</param>
        /// <param name="mantenimiento">Datos del mantenimiento con las actualizaciones.</param>
        /// <returns>Respuesta de la operación con el mantenimiento actualizado o un error.</returns>
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
                existingMantenimiento.ArrendatarioId = mantenimiento.ArrendatarioId;
                existingMantenimiento.PropietarioId = mantenimiento.PropietarioId;
                
                _mantenimientoRepository.Update(existingMantenimiento);
                await _unitOfWork.CompleteAsync();
                return new MantenimientoResponse(existingMantenimiento);
            }
            catch (Exception e)
            {
                return new MantenimientoResponse($"An error occurred while updating the mantenimiento: {e.Message}");
            }
        }

        /// <summary>
        /// Elimina un mantenimiento de manera asincrónica de la base de datos.
        /// </summary>
        /// <param name="mantenimientoId">Identificador del mantenimiento a eliminar.</param>
        /// <returns>Respuesta de la operación con el mantenimiento eliminado o un error.</returns>
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